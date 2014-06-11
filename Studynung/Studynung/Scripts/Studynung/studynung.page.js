"undefined" == typeof studynung && (studynung = {});
"undefined" == typeof studynung.page && (studynung.page = {});

studynung.page.ProtectiveEarthing = {
    init: function (id) {
        this.processId = id;
        if (this.processId != -1) {
            $("#btnContinue").fadeToggle();
        }
        $("#btnStart").click(function () {
            
            if (studynung.page.ProtectiveEarthing.processId != -1) {
                var result = confirm("Ви впевнені, що хочите розпочати цю лабораторну роботу знову?");
                if (result == true) {
                    window.location.href = "ProtectiveEarthing/Calculation";
                }
            } else {
                window.location.href = "ProtectiveEarthing/Calculation";
            }
        });

    }
}

studynung.page.ProtectiveEarthing.calc = {
	init: function() {
	    
	}
}