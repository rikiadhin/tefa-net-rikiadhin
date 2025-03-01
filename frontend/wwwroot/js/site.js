// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function formatDateTime(dateString) {
    let date = new Date(dateString);
    let formatter = new Intl.DateTimeFormat("id-ID", {
        year: "numeric",
        month: "2-digit",
        day: "2-digit",
        hour: "2-digit",
        minute: "2-digit",
        second: "2-digit"
    });
    return formatter.format(date);
}

function GetData() {
    console.log("Fetching data...");
    let startTime = performance.now();

    $.ajax({
        url: "http://localhost:5069/api/TodoList",
        method: "GET",
        success: function (res) {
            var tableString = "";
            $.each(res, function (index, value) {
                tableString += "<tr><td>" + (index + 1) + "</td>" +
                    "<td>" + value.judul + "</td>" +
                    "<td>" + value.description + "</td>" +
                    "<td>" + formatDateTime(value.createdAt) + "</td>" +
                    "<td>" + formatDateTime(value.updatedAt) + "</td>" +
                    `<td>
                                    <div class="table-actions">
                                    <button class="btn btn-primary btn-edit" data-id="${value.todoListId}">Edit</button>
                                    <button class="btn btn-danger btn-delete" data-id="${value.todoListId}">Delete</button>
                                </div>
                                </td>` +
                    "</tr>";
            });
            $("#table-data").html(tableString);  
            let endTime = performance.now();
            let executionTime = (endTime - startTime).toFixed(3);

            console.log(`Executed in ${executionTime} ms`);
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function AddData() { 
    let judul = $("#judul").val();
    let description = $("#description").val(); 
    $.ajax({
        url: "http://localhost:5069/api/TodoList",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify({ judul: judul, description: description }),
        success: function (response) { 
            $("#modalAddData").modal("hide"); 
            $("#formAddData")[0].reset(); 
            GetData(); 
        },
        error: function (error) {
            console.error("Gagal menambahkan data:", error);
            alert("Gagal menambahkan data!");
        }
    });
}

function EditData() {
    let id = $("#editId").val();
    let judul = $("#editJudul").val();
    let description = $("#editDescription").val(); 

    $.ajax({
        url: `http://localhost:5069/api/TodoList/${id}`,
        method: "PUT",
        contentType: "application/json",
        data: JSON.stringify({ judul: judul, description: description }),
        success: function (response) { 
            $("#modalEditData").modal("hide");
            GetData(); // Refresh data di tabel
        },
        error: function (error) {
            console.error("❌ Gagal memperbarui data:", error); 
        }
    });
}

function DeleteData(id) { 
    if (confirm("Apakah Anda yakin ingin menghapus data ini?")) {
        $.ajax({
            url: `http://localhost:5069/api/TodoList/${id}`,
            method: "DELETE",
            success: function () {
                GetData();
            },
            error: function (error) {
                console.log(error);
                alert("Gagal menghapus data!");
            }
        });
    }
} 

$(document).ready(function () {
    console.log("✅ Document Ready!");

    // Load modals terlebih dahulu sebelum event handler
    let loadModalAdd = $.get("/Modal/Add").done(function (data) {
        $("#modals").append(data); 
    }).fail(function () {
        console.error("❌ Failed to load modal-add.cshtml");
    });

    let loadModalEdit = $.get("/Modal/Edit").done(function (data) {
        $("#modals").append(data); 
    }).fail(function () {
        console.error("❌ Failed to load modal-edit.cshtml");
    });

    // Pastikan modals selesai dimuat sebelum menambahkan event handler
    $.when(loadModalAdd, loadModalEdit).done(function () { 

        // Event handler submit form (menggunakan .on untuk elemen dinamis)
        $(document).on("submit", "#formAddData", function (event) {
            event.preventDefault(); 
            AddData();
        });
        // Event handler tombol add
        $(document).on("click", ".btn-add", function () { 
            $("#modalAddData").modal("show");
        });

        // Event handler tombol edit
        $(document).on("click", ".btn-edit", function () { 
        
            let id = $(this).data("id");
            let judul = $(this).closest("tr").find("td:eq(1)").text();
            let description = $(this).closest("tr").find("td:eq(2)").text(); 
        
            $("#editId").val(id);
            $("#editJudul").val(judul);
            $("#editDescription").val(description);
        
            $("#modalEditData").modal("show");
        });
        // Menangani form submit untuk edit
        $(document).on("submit", "#formEditData", function (event) {
            event.preventDefault(); 
            EditData();
        });

        // Event handler tombol delete
        $(document).on("click", ".btn-delete", function () { 
            var id = $(this).data("id");
            console.log(' id di event delete : ', id);
            DeleteData(id);
        }); 

        console.log("✅ Semua event handler siap!");
    });

    // Load data awal
    GetData();
});

