$(document).ready(function () {

    //ajax
    $.ajax({
        url:'https://localhost:7261/api/employee/getemployees',
        type:'get',
        success:function (data) {
            console.log(data);
            GetEmployeeTable(data)

        },
        error:function (err) {
            console.log(err);
        }
    })


    function GetEmployeeTable(employees) {
        var employeeTable = $("#employeeTable");

        employees.forEach(function (val, index){
            employeeTable.append(`
<tr>
<td>${val.id}</td>
<td>${val.firstName}</td>
<td>${val.lastName}</td>
<td>${val.title}</td>
<td>${val.titleOfCourtesy}</td>
</tr>

`)


        })

    }


    $("#orderBy").on("click", function () {
        $.ajax({
            url: 'https://localhost:7261/api/employee/getemployeesorderby',
            type: 'get',
            success: function (data) {
                console.log(data);
                GetEmployeesOrderBy(data)

            },
            error: function (err) {
                console.log(err);
            }
        })
    });

  
    function GetEmployeesOrderBy(employe) {

        var employeeTable = $("#employeeTableOrderBy");

        employees.forEach(function (val, index) {
            employeeTable.append(`
<tr>
<td>${val.id}</td>
<td>${val.firstName}</td>
<td>${val.lastName}</td>
<td>${val.title}</td>
<td>${val.titleOfCourtesy}</td>
</tr>

`)


        })
    }





    $("#orderByDesc").on("click", function () {
        $.ajax({
            url: 'https://localhost:7261/api/employee/getemployeesorderbydesc',
            type: 'get',
            success: function (data) {
                console.log(data);
                GetEmployeesOrderByDesc(data)

            },
            error: function (err) {
                console.log(err);
            }
        })
    });


    function GetEmployeesOrderByDesc(employe) {

        var employeeTable = $("#employeeTable");

        employees.forEach(function (val, index) {
            employeeTable.append(`
<tr>
<td>${val.id}</td>
<td>${val.firstName}</td>
<td>${val.lastName}</td>
<td>${val.title}</td>
<td>${val.titleOfCourtesy}</td>
</tr>

`)


        })
    }



   
    //Butonun tıklamasını temsil ediyor
    $("#btnSave").on("click", function () {
        CreateEmployee();
    });

    function CreateEmployee() {

        var firstname = $("#firstname").val();
        var lastname = $("#lastname").val();
        var title = $("#title").val();
        var titleOfCourtesy = $("#titleOfCourtesy").val();

        $.ajax({
            url: "https://localhost:7261/api/employee/createemployee",
            type: 'Post',
            data: {
                "firstname":firstname,
                "lastname":lastname,
                "title": title,
                "titleOfCourtesy":titleOfCourtesy
            },
            success: function (result) {
                console.log(result);
            },
            error: function (err) {
                console.log(err)
            }

        })


    }



})


