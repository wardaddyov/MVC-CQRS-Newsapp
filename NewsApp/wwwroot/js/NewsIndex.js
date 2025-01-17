// wwwroot/js/newsIndex.js

document.addEventListener('DOMContentLoaded', function () {
    // Handle Select All checkbox
    const selectAllCheckbox = document.getElementById('selectAll');
    const selectNewsCheckboxes = document.querySelectorAll('.selectNews');
    const deleteSelectedBtn = document.getElementById('deleteSelectedBtn');

    selectAllCheckbox.addEventListener('change', function () {
        selectNewsCheckboxes.forEach(function (checkbox) {
            checkbox.checked = selectAllCheckbox.checked;
        });
    });

    // Update Select All checkbox based on individual selections
    selectNewsCheckboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', function () {
            if (!checkbox.checked) {
                selectAllCheckbox.checked = false;
            } else {
                const allChecked = Array.from(selectNewsCheckboxes).every(cb => cb.checked);
                selectAllCheckbox.checked = allChecked;
            }
        });
    });

    // Handle Delete Selected button click
    deleteSelectedBtn.addEventListener('click', function () {
        const selectedNewsIds = Array.from(selectNewsCheckboxes)
            .filter(cb => cb.checked)
            .map(cb => cb.value);

        if (selectedNewsIds.length === 0) {
            alert('Please select at least one news item to delete.');
            return;
        }

        if (!confirm(`Are you sure you want to delete ${selectedNewsIds.length} selected news item(s)?`)) {
            return;
        }

        // Get the anti-forgery token
        const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

        // Send AJAX request to delete selected news items
        fetch('/News/DeleteSelected', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': token
            },
            body: JSON.stringify({ newsIds: selectedNewsIds })
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    // Remove deleted rows from the table
                    data.deletedNewsIds.forEach(id => {
                        const row = document.getElementById(`newsRow_${id}`);
                        if (row) {
                            row.remove();
                        }
                    });

                    alert('Selected news items have been deleted successfully.');
                } else {
                    alert('An error occurred while deleting news items.');
                }
            })
            .catch(error => {
                console.error('Error:', error);
                alert('An error occurred while deleting news items.');
            });
    });
});
