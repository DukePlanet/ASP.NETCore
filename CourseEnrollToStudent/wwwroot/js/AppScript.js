

$('#DeptId').change(function () {
    getStudent();
    getcourse();
});


var getStudent = function () {
    //var url = '@Url.Content("~/")' + "Demo/GetSubCategory";
    var url = "/Enrolls/GetStudentsByDept"
    var deptId = $("#DeptId").val();
    $.getJSON(url, { deptId: deptId }, function (data) {
        var items = '';
        $("#StudentId").empty();
        $.each(data, function (i, student) {
            items += "<option value='" + student.value + "'>" + student.text + "</option>";
        });
        $('#StudentId').html(items);
    });
}


var getcourse = function () {
    var url = "/Enrolls/GetCoursesByDept"
    var deptId = $("#DeptId").val();
    $.getJSON(url, { deptId: deptId }, function (data) {
        var items = '';
        $("#CourseId").empty();
        $.each(data, function (i, course) {
            items += "<option value='" + course.value + "'>" + course.text + "</option>";
        });
        $('#CourseId').html(items);
    });
}