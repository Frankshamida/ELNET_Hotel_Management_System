document.addEventListener("DOMContentLoaded", function () {
    // Sidebar Toggle Functionality
    const sidebar = document.getElementById("sidebar");
    const toggleButton = document.getElementById("toggleSidebar");
    const mainContent = document.getElementById("mainContent");

    if (sidebar && toggleButton && mainContent) {
        // Toggle sidebar on button click
        toggleButton.addEventListener("click", function () {
            sidebar.classList.toggle("collapsed");
            mainContent.classList.toggle("collapsed");
        });

        // Expand sidebar on hover (if collapsed)
        sidebar.addEventListener("mouseenter", function () {
            if (sidebar.classList.contains("collapsed")) {
                sidebar.classList.remove("collapsed");
                mainContent.classList.remove("collapsed");
            }
        });

        // Collapse sidebar when mouse leaves (if not toggled)
        sidebar.addEventListener("mouseleave", function () {
            if (!sidebar.classList.contains("collapsed")) {
                sidebar.classList.add("collapsed");
                mainContent.classList.add("collapsed");
            }
        });
    }

    // Initialize jQuery Functionality
    $(document).ready(function () {
        // Handle "Create User" button click
        $('#createUserBtn').click(function (e) {
            e.preventDefault(); // Prevent default link behavior

            // Fetch the CreateUser.cshtml content using AJAX
            $.ajax({
                url: '/Dashboards/CreateUser', // URL to the CreateUser action
                type: 'GET',
                success: function (response) {
                    // Inject the fetched content into the #content div
                    $('#content').html(response);

                    // Add event listener for the Generate Company ID button
                    $('#generateCompanyIdBtn').click(function () {
                        const uniqueId = Math.floor(10000000 + Math.random() * 90000000).toString();
                        $('input[name="CompanyId"]').val(uniqueId);
                    });

                    // Handle form submission via AJAX
                    $('#createUserForm').on('submit', function (e) {
                        e.preventDefault(); // Prevent default form submission

                        $.ajax({
                            url: '/Dashboards/ViewEmployees',
                            type: 'POST',
                            data: $(this).serialize(),
                            success: function (response) {
                                if (response.success) {
                                    // Show success message
                                    $('#successMessage').text(response.message).show();

                                    // Reset form fields
                                    $('#createUserForm')[0].reset();

                                    // Hide success message after 3 seconds
                                    setTimeout(function () {
                                        $('#successMessage').hide();
                                    }, 3000);
                                }
                            },
                            error: function (xhr, status, error) {
                                console.error('Error submitting form:', error);
                            }
                        });
                    });

                    // Disable the submit button initially
                    const submitButton = $('#createUserForm button[type="submit"]');
                    submitButton.prop('disabled', true);

                    // Add event listeners to form fields to enable/disable the submit button
                    $('#createUserForm input, #createUserForm select').on('input change', function () {
                        let isFormValid = true;

                        // Check if all required fields are filled
                        $('#createUserForm input[required], #createUserForm select[required]').each(function () {
                            if ($(this).val() === '') {
                                isFormValid = false;
                                return false; // Exit the loop early if any field is empty
                            }
                        });

                        // Enable/disable the submit button based on form validity
                        submitButton.prop('disabled', !isFormValid);
                    });
                },
                error: function (xhr, status, error) {
                    console.error('Error loading Create User form:', error);
                    $('#content').html('<p class="text-danger">Error loading form. Please try again.</p>');
                }
            });
        });

        // Handle "View Employees" button click
        $('#viewEmployeesBtn').click(function (e) {
            e.preventDefault(); // Prevent default link behavior

            // Fetch the ViewEmployees.cshtml content using AJAX
            $.ajax({
                url: '/Dashboards/ViewEmployees', // URL to the ViewEmployees action
                type: 'GET',
                success: function (response) {
                    // Inject the fetched content into the #content div
                    $('#content').html(response);

                    // Initialize search functionality after loading the table
                    initializeSearch('#employeeTable');
                },
                error: function (xhr, status, error) {
                    console.error('Error loading View Employees:', error);
                    $('#content').html('<p class="text-danger">Error loading employees. Please try again.</p>');
                }
            });
        });

        // Handle "View Rooms" button click
        $('#viewRoomBtn').click(function (e) {
            e.preventDefault(); // Prevent default link behavior

            // Fetch the ViewRooms.cshtml content using AJAX
            $.ajax({
                url: '/Dashboards/ViewRooms', // URL to the ViewRooms action
                type: 'GET',
                success: function (response) {
                    // Inject the fetched content into the #content div
                    $('#content').html(response);

                    // Initialize search functionality after loading the table
                    initializeSearch('#roomTable');
                },
                error: function (xhr, status, error) {
                    console.error('Error loading View Rooms:', error);
                    $('#content').html('<p class="text-danger">Error loading rooms. Please try again.</p>');
                }
            });
        });

        // Handle "Create Room" button click
        $('#createRoomBtn').click(function (e) {
            e.preventDefault(); // Prevent default link behavior

            // Fetch the CreateRoom.cshtml content using AJAX
            $.ajax({
                url: '/Dashboards/CreateRoom', // URL to the CreateRoom action
                type: 'GET',
                success: function (response) {
                    // Inject the fetched content into the #content div
                    $('#content').html(response);

                    // Handle form submission via AJAX
                    $('#createRoomForm').on('submit', function (e) {
                        e.preventDefault(); // Prevent default form submission

                        $.ajax({
                            url: '/Dashboards/CreateRoom',
                            type: 'POST',
                            data: $(this).serialize(),
                            success: function (response) {
                                if (response.success) {
                                    // Show success message
                                    $('#successMessage').text(response.message).show();

                                    // Reset form fields
                                    $('#createRoomForm')[0].reset();

                                    // Hide success message after 3 seconds
                                    setTimeout(function () {
                                        $('#successMessage').hide();
                                    }, 3000);
                                }
                            },
                            error: function (xhr, status, error) {
                                console.error('Error submitting form:', error);
                            }
                        });
                    });
                },
                error: function (xhr, status, error) {
                    console.error('Error loading Create Room form:', error);
                    $('#content').html('<p class="text-danger">Error loading form. Please try again.</p>');
                }
            });
        });

        // Function to initialize search functionality
        function initializeSearch(tableId) {
            // Function to filter the table based on search input
            function filterTable() {
                const searchText = $('#searchInput').val().toLowerCase();

                $(`${tableId} tbody tr`).each(function () {
                    const roomNumber = $(this).find('td:eq(0)').text().toLowerCase();
                    const roomType = $(this).find('td:eq(1)').text().toLowerCase();
                    const status = $(this).find('td:eq(2)').text().toLowerCase();
                    const pricePerNight = $(this).find('td:eq(3)').text().toLowerCase();
                    const maxOccupancy = $(this).find('td:eq(4)').text().toLowerCase();
                    const amenities = $(this).find('td:eq(5)').text().toLowerCase();

                    const matchesSearch = (
                        roomNumber.includes(searchText) ||
                        roomType.includes(searchText) ||
                        status.includes(searchText) ||
                        pricePerNight.includes(searchText) ||
                        maxOccupancy.includes(searchText) ||
                        amenities.includes(searchText)
                    );

                    if (matchesSearch) {
                        $(this).show();
                    } else {
                        $(this).hide();
                    }
                });
            }

            // Attach event listener to search bar
            $('#searchInput').on('input', filterTable);
        }

        // Generate Random Company ID
        document.getElementById('generateCompanyIdBtn')?.addEventListener('click', function () {
            const uniqueId = Math.floor(10000000 + Math.random() * 90000000).toString();
            document.querySelector('input[name="CompanyId"]').value = uniqueId;
        });
    });
});