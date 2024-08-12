
document.addEventListener('DOMContentLoaded', function () {
    const deleteButtons = document.querySelectorAll('.Js-delete');

    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            const itemId = this.getAttribute('data-id');

            Swal.fire({
                title: "Are you sure?",
                text: "You won't be able to revert this!",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Yes, delete it!"
            }).then((result) => {
                if (result.isConfirmed) {

                    const ajaxCall = new XMLHttpRequest();
                    ajaxCall.open('DELETE', `/Instructor/Delete/${itemId}`, true)
                    ajaxCall.send();

                    Swal.fire({
                        title: "Deleted!",
                        text: "Your file has been deleted.",
                        icon: "success"
                    });
                    
                    button.parentElement.parentElement.remove()
                }
            });
        
        });
    });
});











