
//Function to retrieve the School Section if anyone has done planning in any SchoolSection books to the current user

//function GetSchoolSections(id) {
//    $.get("/AcademicCalendar/GetSchoolSections", { YearId: parseInt($(`#${id}`).val(), 10) }, function (data) {
//        $("#SchoolSectionId").empty();
//        $("#GradeId").empty();
//        $("#ClassId").empty();
//        $("#BookId").empty();
//        $("#SchoolSectionId").append("<Option value='0'>" + "---Select Section Please---" + "</Option>");
//        $.each(data, function (index, row) {
//            console.log(row);
//            $("#SchoolSectionId").append("<Option value='" + row.schoolSectionId + "'>" + row.sectionName + "</Option>")
//        });
//    });
//};

//function GetGrades(id) {
//    $.get("/AcademicCalendar/GetGrades", { SchoolSectionId: parseInt($(`#${id}`).val(), 10) }, function (data) {
//        $("#GradeId").empty();
//        $("#ClassId").empty();
//        $("#BookId").empty();
//        $("#GradeId").append("<Option value='0'>" + "---Select Grade Please---" + "</Option>");
//        $.each(data, function (index, row) {
//            console.log(row);
//            $("#GradeId").append("<Option value='" + row.gradeId + "'>" + row.gradeName + "</Option>")
//        });
//    });
//};



//Allocations Dynamic Data

//ExamController Functions

//This function below is used in AddExamPaper Funciton to get classes dynamically
function GetClasses(id) {
    $.get("/Exam/GetClasses", { SchoolSectionId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#SectionId").empty();
        $("#SubjectId").empty();
        $("#BookId").empty();
        //debugger;
        $("#SectionId").append("<Option selected value>" + "---Select Subject Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(row);
            $("#SectionId").append("<Option value='" + row.sectionId + "'>" + row.sectionName + "</Option>")
        });
    });
};

function GetExamSubjects(id) {
    $.get("/Exam/GetSubjects", { ClasssId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#SubjectId").empty();
        $("#BookId").empty();
        //debugger;
        $("#SubjectId").append("<Option selected value>" + "---Select Subject Please---" + "</Option>");
        $.each(data, function (index, row) {
            $("#SubjectId").append("<Option value='" + row.subjectId + "'>" + row.subjectName + "</Option>")
        });
    });
};

function GetClassesForPerInd(id) {
    $.get("/Exam/GetClassesForPerInd", { SchoolSectionId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#SectionId").empty();
        //debugger;
        $("#SectionId").append("<Option selected value>" + "---Select Subject Please---" + "</Option>");
        $.each(data, function (index, row) {
            $("#SectionId").append("<Option value='" + row.sectionId + "'>" + row.sectionName + "</Option>")
        });
    });
};

//The below funciton to get subjects dynamically used in AcademicPlanning in AcademicCalendarController 
function GetSubjects(id) {
    $.get("/AcademicCalendar/GetSubjects", { ClasssId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#SubjectId").empty();
        //debugger;
        $("#SubjectId").append("<Option selected value>" + "---Select Subject Please---" + "</Option>");
        $.each(data, function (index, row) {
            $("#SubjectId").append("<Option value='" + row.subjectId + "'>" + row.subjectName + "</Option>")
        });
    });
};

function GetBooks(id) {
    $.get("/academiccalendar/GetBooks", { SubjectId: parseInt($(`#${id}`).val(), 10), SubjectId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#BookId").empty();
        $("#BookId").append("<option selected value>" + "---Select Book Please---" + "</option>");
        $.each(data, function (index, row) {
            $("#BookId").append("<option value='" + row.bookId + "'>" + row.bookName + "</option>")
        });
    });
};

function GetUnits(id) {
    $.get("/academiccalendar/GetUnits", { PlanId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#UnitId").empty();
        $("#UnitId").append("<option selected value>" + "---Select Unit Please---" + "</option>");
        $.each(data, function (index, row) {
            $("#UnitId").append("<option value='" + row.unitId + "'>" + row.unitName + "</option>")
        });
    });
};
//Used in AcademicPlannings
function GetTerms(id) {
    //debugger;
    $.get("/academiccalendar/GetTerms", { YearId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#TermId").empty();
        $("#TermId").append("<option selected value>" + "---Select Term Please---" + "</option>");
        $.each(data, function (index, row) {
            $("#TermId").append("<option value='" + row.termId + "'>" + row.termName + "</option>")
        });
    });
};

function Slicer(s) {
    //debugger;
    if (s && typeof s === 'string') {
        var sArray = s.split(' ');
        if (sArray.length > 4) {
            var truncatedTmName = sArray.slice(0, 4).join(' ');
            var truncatedTmNameWithEllipsis = truncatedTmName + '...';
            return truncatedTmNameWithEllipsis;
        } else {
            return s;
        }
    } else {
        return '';
    }
}




//function GetChapters(id, planId) {
//    $.get("/academiccalendar/GetChapters", { UnitId: parseInt($(`#${id}`).val(), 10), PlanId: parseInt(planId, 10) }, function (data) {
//        $("#ChapterId").empty();
//        $("#ChapterId").append("<option selected value>" + "---Select Chapter Please---" + "</option>");
//        $.each(data, function (index, row) {
//            $("#ChapterId").append("<option value='" + row.chapterId + "'>" + row.chapterName + "</option>")
//        });
//    });
//};
//function GetTopics(id, planId, unitId) {
//    $.get("/academiccalendar/GetTopics", { ChapterId: parseInt($(`#${id}`).val(), 10), PlanId: parseInt(planId, 10), UnitId: parseInt(unitId, 10) }, function (data) {
//        $("#TopicId").empty();
//        $("#TopicId").append("<option selected value>" + "---Select Topic Please---" + "</option>");
//        $.each(data, function (index, row) {
//            $("#TopicId").append("<option value='" + row.topicId + "'>" + row.topicName + "</option>")
//        });
//    });
//};

function GetChapters(id) {
    $.get("/academiccalendar/GetChapters", { UnitId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#ChapterId").empty();
        $("#UnitStartDate").val('');
        $("#UnitStartDate").removeAttr("min");
        $("#UnitStartDate").removeAttr("max");
        $("#UnitEndDate").val('');
        $("#UnitEndDate").removeAttr("min");
        $("#UnitEndDate").removeAttr("max");
        $("#UnitWBStartPage").val("");
        $("#UnitWBEndPage").val("");
        $("#ChapterStartDate").val('');
        $("#ChapterStartDate").removeAttr("min");
        $("#ChapterStartDate").removeAttr("max");
        $("#ChapterEndDate").val('');
        $("#ChapterEndDate").removeAttr("min");
        $("#ChapterEndDate").removeAttr("max");
        $("#ChapterWBStartPage").val("");
        $("#ChapterWBEndPage").val("");
        $("#TopicId").empty();
        $("#TopicStartDate").val('');
        $("#TopicStartDate").removeAttr("min");
        $("#TopicStartDate").removeAttr("max");
        $("#TopicEndDate").val('');
        $("#TopicEndDate").removeAttr("min");
        $("#TopicEndDate").removeAttr("max");
        $("#TopicWBStartPage").val("");
        $("#TopicWBEndPage").val("");
        $("#SubTopicId").empty();
        $("#SubTopicStartDate").val('');
        $("#SubTopicStartDate").removeAttr("min");
        $("#SubTopicStartDate").removeAttr("max");
        $("#SubTopicEndDate").val('');
        $("#SubTopicEndDate").removeAttr("min");
        $("#SubTopicEndDate").removeAttr("max");
        $("#SubTopicWorkBookSP").val("");
        $("#SubTopicWorkBookEP").val("");
        $("#TeachingMethodologyDesc").val("");
        $("#ChapterId").append("<option selected value>" + "---Select Chapter Please---" + "</option>");
        if (data.length !== 0) {
            //$("#ChapterId").rules("add", {
            //    required: true,
            //    messages: {
            //        required: "Chapter Is Required"
            //    }
            //});
            $("#UnitStartDate").rules("add", {
                required: true,
                messages: {
                    required: "Start Date Is Required"
                }
            });
            $("#UnitEndDate").rules("add", {
                required: true,
                messages: {
                    required: "Start Date Is Required"
                }
            });
        }
        else {
            //$("#ChapterId").rules('remove', 'required');
            $("#UnitStartDate").rules('remove', 'required');
            $("#UnitEndDate").rules('remove', 'required');
        }
        $.each(data, function (index, row) {
            $("#ChapterId").append("<option value='" + row.chapterId + "'>" + row.chapterName + "</option>")
        });
    });
};

function GetTopics(id) {
    $.get("/academiccalendar/GetTopics", { ChapterId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#ChapterStartDate").val('');
        $("#ChapterEndDate").val('');
        $("#ChapterWBStartPage").val("");
        $("#ChapterWBEndPage").val("");
        $("#TopicId").empty();
        $("#TopicStartDate").val('');
        $("#TopicEndDate").val('');
        $("#TopicWBStartPage").val("");
        $("#TopicWBEndPage").val("");
        $("#SubTopicId").empty();
        $("#SubTopicStartDate").val('');
        $("#SubTopicEndDate").val('');
        $("#SubTopicWorkBookSP").val("");
        $("#SubTopicWorkBookEP").val("");
        $("#TeachingMethodologyDesc").val("");
        if (data.length !== 0) {
            $("#ChapterStartDate").rules("add", {
                required: true,
                messages: {
                    required: "Start Date Is Required"
                }
            });
            $("#ChapterEndDate").rules("add", {
                required: true,
                messages: {
                    required: "Start Date Is Required"
                }
            });
            $("#TopicId").append("<option selected value>" + "---Select Topic Please---" + "</option>");
        }
        else {
            $("#ChapterStartDate").rules('remove', 'required');
            $("#ChapterEndDate").rules('remove', 'required');
        }
        $.each(data, function (index, row) {
            $("#TopicId").append("<option value='" + row.topicId + "'>" + row.topicName + "</option>")
        });
    });
};

function GetSubTopics(id) {
    $.get("/academiccalendar/GetSubTopics", { TopicId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#TopicStartDate").val('');
        $("#TopicEndDate").val('');
        $("#TopicWBStartPage").val("");
        $("#TopicWBEndPage").val("");
        $("#SubTopicId").empty();
        $("#SubTopicStartDate").val('');
        $("#SubTopicEndDate").val('');
        $("#SubTopicWorkBookSP").val("");
        $("#SubTopicWorkBookEP").val("");
        $("#TeachingMethodologyDesc").val("");
        //debugger;
        if (data.length !== 0 || $("TopicId").val() !== "") {
            //$("#SubTopicId").rules("add", {
            //    required: true,
            //    messages: {
            //        required: "Sub-Topic Is Required"
            //    }
            //});
            $("#TopicStartDate").rules("add", {
                required: true,
                messages: {
                    required: "Start Date Is Required"
                }
            });
            $("#TopicEndDate").rules("add", {
                required: true,
                messages: {
                    required: "Start Date Is Required"
                }
            });
            $("#TeachingMethodologyId").rules("add", {
                required: true,
                messages: {
                    required: "TeachingMethodology Is Required"
                }
            });
            //$("#SubTopicStartDate").rules("add", {
            //    required: true,
            //    messages: {
            //        required: "Start Date Is Required"
            //    }
            //});
            //$("#SubTopicEndDate").rules("add", {
            //    required: true,
            //    messages: {
            //        required: "Start Date Is Required"
            //    }
            //});
            $("#SubTopicId").append("<option selected value>" + "---Select Sub-Topic Please---" + "</option>");
        }
        else {
            //$("#SubTopicId").rules('remove', 'required');
            $("#TopicStartDate").rules('remove', 'required');
            $("#TopicEndDate").rules('remove', 'required');
            $("#TeachingMethodologyId").rules('remove', 'required');
        }
        $.each(data, function (index, row) {
            $("#SubTopicId").append("<option value='" + row.subTopicId + "'>" + row.subTopicName + "</option>")
        });
    });
};


function testFunction(id) {
    var wbElements = $(`.WorkBookPlanned`);
    if ($(`#${id}`).val() !== "") {
        for (var i = 0; i < wbElements.length; i++) {
            $(wbElements[i]).removeClass("d-none");
        }
    } else {
        for (var i = 0; i < wbElements.length; i++) {
            $(wbElements[i]).addClass("d-none");
        }
    }
}

function DatesBound(id) {
    //debugger;
    var selectedDate = new Date($(`#${id}`).val());
    if (id == "UnitStartDate") {
        //$('.datepicker').datepicker('setStartDate', startDate);
        $("#ChapterStartDate").datepicker('setStartDate', selectedDate.toISOString().split('T')[0]);
        //$("#ChapterStartDate").datepicker('destroy').datepicker();
        $("#ChapterEndDate").datepicker('setStartDate', selectedDate.toISOString().split('T')[0]);
        //$("#ChapterEndDate").datepicker('destroy').datepicker();
    }
    else if (id == "ChapterStartDate") {
        $("#TopicStartDate").datepicker('setStartDate', selectedDate.toISOString().split('T')[0]);
        //$("#TopicStartDate").datepicker('destroy').datepicker();
        $("#TopicEndDate").datepicker('setStartDate', selectedDate.toISOString().split('T')[0]);
        //$("#TopicEndDate").datepicker('destroy').datepicker();
    }
    else if (id == "TopicStartDate") {
        $("#SubTopicStartDate").datepicker('setStartDate', selectedDate.toISOString().split('T')[0]);
        //$("#SubTopicStartDate").datepicker('destroy').datepicker();
        $("#SubTopicEndDate").datepicker('setStartDate', selectedDate.toISOString().split('T')[0]);
        //$("#SubTopicStartDate").datepicker('destroy').datepicker();
    }
    else if (id == "UnitEndDate") {
        $("#ChapterStartDate").datepicker('setEndDate', selectedDate.toISOString().split('T')[0]);
        //$("#ChapterStartDate").datepicker('destroy').datepicker();
        $("#ChapterEndDate").datepicker('setEndDate', selectedDate.toISOString().split('T')[0]);
        //$("#ChapterEndDate").datepicker('destroy').datepicker();
        var startDate = new Date($(`#UnitStartDate`).val());
        if (startDate > selectedDate) {
            $.validator.addMethod("customRule", function (value, element) {
                return value >= startDate;
            }, "End Date Must Be Greater Than Or Equal To Start Date.");

            $("#UnitEndDate").rules('add', {
                customRule: true
            });
        }
        else {
            $("#UnitEndDate").rules('remove', 'customRule');
        }
    }
    else if (id == "ChapterEndDate") {
        $("#TopicStartDate").datepicker('setEndDate', selectedDate.toISOString().split('T')[0]);
        //$("#TopicStartDate").datepicker('destroy').datepicker();
        $("#TopicEndDate").datepicker('setEndDate', selectedDate.toISOString().split('T')[0]);
        //$("#TopicEndDate").datepicker('destroy').datepicker();
        var startDate = new Date($(`#ChapterStartDate`).val());
        if (startDate > selectedDate) {
            $.validator.addMethod("customRule", function (value, element) {
                return value >= startDate;
            }, "End Date Must Be Greater Than Or Equal To Start Date.");

            $("#ChapterEndDate").rules('add', {
                customRule: true
            });
        }
        else {
            $("#ChapterEndDate").rules('remove', 'customRule');
        }
    }
    else if (id == "TopicEndDate") {
        $("#SubTopicStartDate").datepicker('setEndDate', selectedDate.toISOString().split('T')[0]);
        //$("#SubTopicStartDate").datepicker('destroy').datepicker();
        $("#SubTopicEndDate").datepicker('setEndDate', selectedDate.toISOString().split('T')[0]);
        //$("#SubTopicEndDate").datepicker('destroy').datepicker();
        var startDate = new Date($(`#TopicStartDate`).val());
        if (startDate > selectedDate) {
            $.validator.addMethod("customRule", function (value, element) {
                return value >= startDate;
            }, "End Date Must Be Greater Than Or Equal To Start Date.");

            $("#TopicEndDate").rules('add', {
                customRule: true
            });
        }
        else {
            $("#TopicEndDate").rules('remove', 'customRule');
        }
    }
    else if (id == "SubTopicEndDate") {
        var startDate = new Date($(`#SubTopicStartDate`).val());
        if (startDate > selectedDate) {
            $.validator.addMethod("customRule", function (value, element) {
                return value >= startDate;
            }, "End Date Must Be Greater Than Or Equal To Start Date.");

            $("#SubTopicEndDate").rules('add', {
                customRule: true
            });
        }
        else {
            $("#SubTopicEndDate").rules('remove', 'customRule');
        }
    }
}
function WBPagesBound(id) {
    //debugger;
    var selectedWBPage = $(`#${id}`).val();
    if (id == "UnitWBStartPage") {
        $("#ChapterWBStartPage, #ChapterWBEndPage, #TopicWBStartPage, #TopicWBEndPage, #SubTopicWorkBookSP, #SubTopicWorkBookEP").val("");
        $("#ChapterWBStartPage, #ChapterWBEndPage, #TopicWBStartPage, #TopicWBEndPage, #SubTopicWorkBookSP, #SubTopicWorkBookEP").attr('min', '0');
        $("#ChapterWBStartPage").attr('min', selectedWBPage);
        $("#ChapterWBEndPage").attr('min', selectedWBPage);
    }
    else if (id == "ChapterWBStartPage") {
        $("#TopicWBStartPage, #TopicWBEndPage, #SubTopicWorkBookSP, #SubTopicWorkBookEP").val("");
        $("#TopicWBStartPage, #TopicWBEndPage, #SubTopicWorkBookSP, #SubTopicWorkBookEP").attr('min', '0');
        $("#TopicWBStartPage").attr('min', selectedWBPage);
        $("#TopicWBEndPage").attr('min', selectedWBPage);
    }
    else if (id == "TopicWBStartPage") {
        $("#SubTopicWorkBookSP, #SubTopicWorkBookEP").val("");
        $("#SubTopicWorkBookSP, #SubTopicWorkBookEP").attr('min', '0');
        $("#SubTopicWorkBookSP").attr('min', selectedWBPage);
        $("#SubTopicWorkBookEP").attr('min', selectedWBPage);
    }
    else if (id == "UnitWBEndPage") {
        $("#ChapterWBStartPage, #ChapterWBEndPage, #TopicWBStartPage, #TopicWBEndPage, #SubTopicWorkBookSP, #SubTopicWorkBookEP").val("");
        $("#ChapterWBStartPage, #ChapterWBEndPage, #TopicWBStartPage, #TopicWBEndPage, #SubTopicWorkBookSP, #SubTopicWorkBookEP").attr('max', '0');
        $("#ChapterWBStartPage").attr('max', selectedWBPage);
        $("#ChapterWBEndPage").attr('max', selectedWBPage);
        var uwbsp = parseInt($("#UnitWBStartPage").val(), 10);
        if (parseInt(selectedWBPage, 10) < uwbsp) {
            $.validator.addMethod("customRule", function (value, element) {
                return parseInt(value, 10) >= uwbsp;
            }, "End Page Must Be Greater Than Or Equal To Start Page.");

            $("#UnitWBEndPage").rules('add', {
                customRule: true
            });
        }
        else {
            $("#UnitWBEndPage").rules('remove', 'customRule');
        }
    }
    else if (id == "ChapterWBEndPage") {
        $("#TopicWBStartPage, #TopicWBEndPage, #SubTopicWorkBookSP, #SubTopicWorkBookEP").val("");
        $("#TopicWBStartPage, #TopicWBEndPage, #SubTopicWorkBookSP, #SubTopicWorkBookEP").attr('max', '0');
        $("#TopicWBStartPage").attr('max', selectedWBPage);
        $("#TopicWBEndPage").attr('max', selectedWBPage);
        var cwbsp = parseInt($("#ChapterWBStartPage").val(), 10);
        if (parseInt(selectedWBPage, 10) < cwbsp) {
            $.validator.addMethod("customRule", function (value, element) {
                return parseInt(value, 10) >= uwbsp;
            }, "End Page Must Be Greater Than Or Equal To Start Page.");

            $("#ChapterWBEndPage").rules('add', {
                customRule: true
            });
        }
        else {
            $("#ChapterWBEndPage").rules('remove', 'customRule');
        }
    }
    else if (id == "TopicWBEndPage") {
        $("#SubTopicWorkBookSP, #SubTopicWorkBookEP").val("");
        $("#SubTopicWorkBookSP, #SubTopicWorkBookEP").attr('max', '0');
        $("#SubTopicWorkBookSP").attr('max', selectedWBPage);
        $("#SubTopicWorkBookEP").attr('max', selectedWBPage);
        var twbsp = parseInt($("#TopicWBStartPage").val(), 10);
        if (parseInt(selectedWBPage, 10) < twbsp) {
            $.validator.addMethod("customRule", function (value, element) {
                return parseInt(value, 10) >= uwbsp;
            }, "End Page Must Be Greater Than Or Equal To Start Page.");

            $("#TopicWBEndPage").rules('add', {
                customRule: true
            });
        }
        else {
            $("#TopicWBEndPage").rules('remove', 'customRule');
        }
    }
    else if (id == "SubTopicWorkBookEP") {
        var Stwbsp = parseInt($("#SubTopicWorkBookSP").val(), 10);
        if (parseInt(selectedWBPage, 10) < Stwbsp) {
            $.validator.addMethod("customRule", function (value, element) {
                return parseInt(value, 10) >= uwbsp;
            }, "End Page Must Be Greater Than Or Equal To Start Page.");

            $("#SubTopicWorkBookEP").rules('add', {
                customRule: true
            });
        }
        else {
            $("#SubTopicWorkBookEP").rules('remove', 'customRule');
        }
    }
}
function SubjectChanged(id) {
    console.log("I'm Selected!");
    $.get("/AcademicCalendar/GetBooks", { SubjectId: parseInt($(`#${id}`).val(), 10), GradeId: $("#GradeId").val() }, function (data) {
        $("#BookId").empty();
        $("#BookId").append("<Option value='@null'>" + "---Select Book Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(data);
            //console.log(index);
            console.log(row);
            $("#BookId").append("<Option value='" + row.bookId + "'>" + row.bookName + "</Option>")
        });
    });
};


function Gradchange(id) {
    //debugger;
    console.log($(`#${id}`).val());
    $("#SubjectId").val('0');
    $("#BookId").val('0');
    $.get("/AcademicCalendar/GetSubjects", { GradeId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#SubjectId").empty();
        $("#SubjectId").append("<Option value='@null'>" + "---Select Subject Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(data);
            //console.log(index);
            console.log(row);
            $("#SubjectId").append("<Option value='" + row.subjectId + "'>" + row.subjectName + "</Option>")
        });
    });
};

function SchoolSectionChange(id) {
    //debugger;
    //console.log(parseInt($("${'#id'}").val(),10));
    $("#GradeId").val('0');
    $("#SubjectId").val('0');
    $("#BookId").val('0');
    $.get("/AcademicCalendar/GetGrades", { SchoolSectionId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#GradeId").empty();
        $("#GradeId").append("<Option value='@null'>" + "---Select Grade Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(data);
            //console.log(index);
            console.log(row);
            $("#GradeId").append("<Option value='" + row.gradeId + "'>" + row.gradeName + "</Option>")
        });
    });
};

//Function to retrieve the allocated books to the current user

function GetClassBooks(id) {
    //debugger;
    //console.log(parseInt($("${'#id'}").val(),10));
    //debugger;
    $.get("/AcademicCalendar/GetClassBooks", { CLassId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#BookId").empty();
        $("#BookId").append("<Option value='@null'>" + "---Select Class Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(data);
            //console.log(index);
            console.log(row);
            $("#BookId").append("<Option value='" + row.bookId + "'>" + row.bookName + "</Option>")
        });
    });
};

//Function to choose the employee type used in Add and Update Employee

function SelectEmployeeType(id) {
    //debugger;
    var empType = $(`#${id}`).val();
    if (empType == 1) {
        var temporaries = document.getElementsByClassName("termporary");
        for (var i = 0; i < temporaries.length; i++) {
            temporaries[i].classList.add("d-none");
        }
        var perm = document.getElementsByClassName("permanent");
        for (var j = 0; j < perm.length; j++) {
            perm[j].classList.remove("d-none");
        }
    }
    else if (empType == 2) {
        var perm = document.getElementsByClassName("permanent");
        for (var j = 0; j < perm.length; j++) {
            perm[j].classList.add("d-none");
        }
        var temporaries = document.getElementsByClassName("termporary");
        for (var i = 0; i < temporaries.length; i++) {
            temporaries[i].classList.remove("d-none");
        }
    }
    else {
        var perm = document.getElementsByClassName("permanent");
        for (var j = 0; j < perm.length; j++) {
            perm[j].classList.add("d-none");
        }
        var temporaries = document.getElementsByClassName("termporary");
        for (var i = 0; i < temporaries.length; i++) {
            temporaries[i].classList.add("d-none");
        }
    }
}

//Book, Unit, Chapter, Topic, SubTopic and Planning Write Urdu
function WriteUrdu(id) {
    debugger;
    var cbox = document.getElementById("writeUrdu");
    console.log(cbox.checked)
    if (cbox.checked) {
        document.getElementById("BookName").setAttribute("lang", "ur");
        document.getElementById("Author").setAttribute("lang", "ur");
        document.getElementById("Publisher").setAttribute("lang", "ur");
        document.getElementById("ResourceBook").setAttribute("lang", "ur");
    }
    else {
        document.getElementById("BookName").removeAttribute("lang");
        document.getElementById("Author").removeAttribute("lang");
        document.getElementById("Publisher").removeAttribute("lang");
        document.getElementById("ResourceBook").removeAttribute("lang");
    }
}

//Function to choose the Question type used in Add and Update Chapter Question

function SelectQuestionType(id) {
    //debugger;
    var questionType = $(`#${id}`).val();
    if (questionType == "True False") {
        document.getElementById("MCQ").classList.add("d-none");
        document.getElementById("TrueFalse").classList.remove("d-none");
    }
    else if (questionType == "MCQ") {
        document.getElementById("TrueFalse").classList.add("d-none");
        document.getElementById("MCQ").classList.remove("d-none");
    }
    else {
        document.getElementById("TrueFalse").classList.add("d-none");
        document.getElementById("MCQ").classList.add("d-none");
    }
}

//Funtion to Generate Dynamic Rows for MCQ Quiz

//function AddNewRow(id) {
//    const table = document.getElementById('MCQChoiceTable');
//    const button = document.getElementById(`${id}`);

//    // Add a click event listener to the button
//    button.addEventListener('click', function () {
//        // Create a new table row
//        const newRow = table.insertRow();

//        // Add two cells to the row
//        const cell1 = newRow.insertCell(0);
//        const cell2 = newRow.insertCell(1);

//        // Add the input and select elements to the cells
//        cell1.innerHTML = '<div class="form-group"><label>Topic Name</label><input type="text" class="form-control" placeholder="Enter Choice Please"/></div>';
//        cell2.innerHTML = '<div class="form-group"><label>True or False?</label><select class="form-select" aria-label="Default select example"><option selected value="@null">Please Select Answer</option><option value="@true">True</option><option value="@false">False</option></select></div>';

//    }
//}


//function to select all the permissions on Add and Update roles page


function SelectAllPermissions() {
    //debugger;
    var checkboxes = document.getElementsByTagName('input');
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].type == 'checkbox') {
            checkboxes[i].checked = true;
        }
    }
}

//Funtion to enable the WBStart and End Pages if any workbook selected during the planning

function EnterWBPages(id) {
    var stringId = id.toString();
    var splitId = stringId.split("__");
    if ($(`#${id}`).val() != "") {
        $(`#${splitId[0]}__WorkBookStartPage`).removeAttr("disabled");
        $(`#${splitId[0]}__WorkBookEndPage`).removeAttr("disabled");
    }
    else {
        $(`#${splitId[0]}__WorkBookStartPage`).attr("disabled", true);
        $(`#${splitId[0]}__WorkBookEndPage`).attr("disabled", true);
    }
}

//Function to retrieve the School Section if anyone has done planning in any SchoolSection books to the current user

function GetClassTeachers(id) {
    //debugger;
    $.get("/Grade/GetClassTeachers", { GradeId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#ClassTeacherId").empty();
        $("#ClassTeacherId").append("<Option value='0'>" + "---Select Class Teacher Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(row);
            $("#ClassTeacherId").append("<Option value='" + row.employeeId + "'>" + row.fName + " " + row.lName + "</Option>")
        });
    });
};

//Function to retrieve the Grade Managers according to the selected school section

function GetGradeManagers(id) {
    //debugger;
    $.get("/Grade/GetGradeManagers", { SectionId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#GradeManagerId").empty();
        $("#GradeManagerId").append("<Option value='0'>" + "---Select Grade Manager Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(row);
            $("#GradeManagerId").append("<Option value='" + row.employeeId + "'>" + row.fName + " " + row.lName + "</Option>")
        });
    });
};

//The following function/calls are used in AcademicActivity Controller
//Function to retrieve the Subjects of the diary

//function GetDiarySubjects(id) {
//    debugger;
//    $.get("/AcademicActivities/GetDiarySubjects", { ClassId: parseInt($(`#${id}`).val(), 10) }, function (data) {
//        $("#SubjectId").empty();
//        $("#SubjectId").append("<Option value='0'>" + "---Select Subject Please---" + "</Option>");
//        $.each(data, function (index, row) {
//            //console.log(row);
//            $("#SubjectId").append("<Option value='" + row.subjectId + "'>" + row.subjectName+ "</Option>")
//        });
//    });
//};

//Function to retrieve the Subjects of the diary

function GetDiaryTopics(id) {
    //debugger;
    $.get("/AcademicActivities/GetDiaryTopics", { PlanId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#TopicId").empty();
        $("#TopicId").append("<Option value='0'>" + "---Select Subject Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(row);
            $("#TopicId").append("<Option value='" + row.topicId + "'>" + row.topicName + "</Option>")
        });
    });
};

//Function to retrieve the Subjects of the diary
function GetDiaryTests(id) {
    //debugger;
    $.get("/AcademicActivities/GetDiaryTests", { PlanId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#TestId").empty();
        $("#TestId").append("<Option value='0'>" + "---Select Test Please---" + "</Option>");
        $.each(data, function (index, row) {
            console.log(row);
            $("#TestId").append("<Option value='" + row.testId + "'>" + row.testTitle + "</Option>")
        });
    });
};

//Function to retrieve the Subjects of the Test

function GetTestSubjects(id) {
    debugger;
    $.get("/AcademicActivities/GetTestSubjects", { ClassId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#SubjectId").empty();
        $("#SubjectId").append("<Option value='0'>" + "---Select Subject Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(row);
            $("#SubjectId").append("<Option value='" + row.subjectId + "'>" + row.subjectName + "</Option>")
        });
    });
};

//Function to retrieve the Books of the Test
function GetTestBooks(id) {
    //debugger;
    $.get("/AcademicActivities/GetTestBooks", { SubjectId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#BookId").empty();
        $("#BookId").append("<Option value='0'>" + "---Select Book Please---" + "</Option>");
        $.each(data, function (index, row) {
            //console.log(row);
            $("#BookId").append("<Option value='" + row.bookId + "'>" + row.bookName + "</Option>")
        });
    });
};

//---------------
function GetParentInfo(id) {
    var cnicInput = document.getElementById(id);
    var parentData = document.getElementsByClassName("parent-info");

    //cnicInput.addEventListener("input", function () {
    if (cnicInput.value.length === 13) {
        $.get("/Student/GetParentInfo", { CNICNo: $(`#${id}`).val().toString() }, function (data) {
            if (data == null) {
                for (var i = 0; i < parentData.length; i++) {
                    parentData[i].classList.remove("d-none");
                }
                $("#ParentId").val(null);
                $("#parentExists").addClass("d-none");
            }
            else {
                for (var i = 0; i < parentData.length; i++) {
                    parentData[i].classList.add("d-none");
                }
                $("#ParentId").val(data.parentId);
                console.log($("#parentExists"));
                $("#parentExists").removeClass("d-none");
            }
        });
    }
    /*});*/

}


//Result Controller
function GetResultTerms(id) {
    $.get("/Result/GetResultTerms", { CalendarId: parseInt($(`#${id}`).val(), 10)}, function (data) {
        $("#print-button").addClass("d-none");
        $("#TermId").empty();
        $("#SectionId").empty();
        $("#PaperId").empty();
        $("#TermId").append("<Option selected value>" + "---Select Assessment Please---" + "</Option>");
        $.each(data, function (index, row) {
            $("#TermId").append("<Option value='" + row.termId + "'>" + row.termName + "</Option>")
        });
    });
};

function GetResultClasses(id) {
    $.get("/Result/GetResultClasses", { TermId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#SectionId").empty();
        $("#PaperId").empty();
        $("#print-button").addClass("d-none");
        $("#SectionId").append("<Option selected value>" + "---Select Class Please---" + "</Option>");
        $.each(data, function (index, row) {
            $("#SectionId").append("<Option value='" + row.sectionId + "'>" + row.sectionName + "</Option>")
        });
    });
};

function GetResultPapers(id) {
    $.get("/Result/GetResultPapers", { SectionId : parseInt($(`#${id}`).val(), 10) }, function (data) {
        $("#PaperId").empty();
        $("#PaperId").append("<Option selected value>" + "---Select Paper Please---" + "</Option>");
        $.each(data, function (index, row) {
            $("#PaperId").append("<Option value='" + row.examPaperId + "'>" + row.examPaperName + "</Option>")
        });
    });
    PrintIfClassTeacher(id);
};

function PrintIfClassTeacher(id) {
    $.get("/Result/PrintIfClassTeacher", { SectionId: parseInt($(`#${id}`).val(), 10) }, function (data) {
        if (data == true) {
            debugger;
            $("#print-button").removeClass("d-none");
        }
        else {
            $("#print-button").addClass("d-none");
        }
    });
};
