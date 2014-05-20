"undefined" == typeof studynung && (studynung = {});
"undefined" == typeof studynung.page && (studynung.page = {});

studynung.page.ProtectiveEarthing = {
	loadTitle: function () {
		this._loadPartial('/LabourProtection/ProtectiveEarthing/Title');
	},
	initTitle: function () {
		$("#btnStart").click(function () {
			studynung.page.ProtectiveEarthing._loadPartial('/LabourProtection/ProtectiveEarthing/Menu');
		});
	},
	initMenu: function () {
		$("#btnDocs").click(function () {
			studynung.page.ProtectiveEarthing._loadPartial('/LabourProtection/ProtectiveEarthing/Theory');
		});
		$("#btnCalc").click(function () {
			studynung.page.ProtectiveEarthing._loadPartial('/LabourProtection/ProtectiveEarthing/Calc');
		});
	},
	_loadPartial: function (url) {
		$.ajax({
			url: url,
			type: 'GET',
			cache: false,
			dataType: "html",
			success: function (data, textStatus, jqXHR) {
				$('#baseContent').html(data);
			}
		});
	}
}

studynung.page.ProtectiveEarthing.calc = {
	init: function() {
	    
	}
}