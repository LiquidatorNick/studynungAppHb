"undefined" == typeof contentPicker && (contentPicker = {});

contentPicker = {
    init: function () {
        this.countGroundingId = -1;
        this.firstPlacementElectrodesId = -1;
        this.groundDeviceTypeId = -1;
        this.locationElectrodesId = -1;
        this.materialId = -1;
        this.profileSectionsId = -1;
        this.typeSoilsId = -1;
        this.resistivitySoilsId = -1;
        this.firstTypeElectrodeId = -1;
        this.secondTypeElectrodeId = -1;
        this.firstLengthElectrodeId = -1;
        this.secondLengthElectrodeId = -1;
        this.heavenId = -1;
        this.humidityId = -1;
        this.firstGroundItemTypeId = -1;
        this.secondGroundItemTypeId = -1;
        this.firstFormulaId = -1;
        this.secondFormulaId = -1;

        // Verification items
        this.isGroupGrounding = false;
        this.isMaterialSelected = false;
        this.isCanLoadProfileSections = false;
        this.isSoilValueValid = false;
        this.isSoilDataInsert = false;

        // private fields
        this._soilIdForResistivitySoil = -1;
    },

    verificationData: function () {
        var items = {
            CountGroundingId: this.countGroundingId,
            FirstPlacementElectrodesId: this.firstPlacementElectrodesId,
            GroundDeviceTypeId: this.groundDeviceTypeId,
            LocationElectodesId: this.locationElectrodesId,
            MaterialId: this.materialId,
            ProfileSectionsId: this.profileSectionsId,
            ResistivitySoilsId: this.resistivitySoilsId,
            TypeSoilsId: this.typeSoilsId,
            FirstTypeElectrodeId: this.firstTypeElectrodeId,
            SecondTypeElectrodeId: this.secondTypeElectrodeId,
            FirstLengthElectrodeId: this.firstLengthElectrodeId,
            SecondLengthElectrodeId: this.secondLengthElectrodeId,
            HeavenId: this.heavenId,
            HumidityId: this.humidityId,
            FirstGroundItemTypeId : this.firstGroundItemTypeId,
            SecondGroundItemTypeId: this.secondGroundItemTypeId,
            FirstFormulaId : this.firstFormulaId,
            SecondFormulaId: this.secondFormulaId
        }
        $.ajax({
            url: "Home/VerificationData",
            type: 'POST',
            cache: false,
            dataType: "html",
            data: items,
            success: function () {
            }
        });

        contentPicker._verifyIds();
        contentPicker._applyVerify();
    },
    _verifyIds: function() {
        this.isGroupGrounding = this.countGroundingId == 1;
        this.isMaterialSelected = this.materialId != -1;
        this.isSoilDataInsert = this.typeSoilsId != -1 && this.resistivitySoilsId != -1;
        this.isSoilValueValid = $.inArray(this.typeSoilsId, this._soilIdForResistivitySoil.split(';')) != -1 && this.typeSoilsId != -1;
    },
    _applyVerify: function() {
        if (this.isGroupGrounding) {
            $(".groupGrounding").fadeIn();
        } else {
            $(".groupGrounding").fadeOut();
        }
        if (!this.isSoilValueValid && this.isSoilDataInsert) {
            alert("Питомий опір ґрунту не відповідає даному типу ґрунту");
            this.resistivitySoilsId = -1;
            this._soilIdForResistivitySoil = -1;
            $("#PcResistivitySoils_contentPicker_textbox").val("");
        }
    },

    pcCountGroundingSelected: function (id) {
        this.countGroundingId = id;
        contentPicker.verificationData();
    },
    pcFirstPlacementElectrodesSelected: function (id) {
        this.firstPlacementElectrodesId = id;
        contentPicker.verificationData();
    },
    pcGroundDeviceTypeSelected: function (id) {
        this.groundDeviceTypeId = id;
        contentPicker.verificationData();
    },
    pcLocationElectrodesTypeSelected: function (id) {
        this.locationElectrodesId = id;
        contentPicker.verificationData();
    },
    pcMaterialSelected: function (id) {
        this.materialId = id;
        $(".PcProfileSections_selectItems_1").each(function () {
            if ($(this).html() != id) {
                $(this).parent().fadeOut();
            } else {
                $(this).parent().fadeIn();
            }
        });
        contentPicker.verificationData();
    },
    pcProfileSectionsSelected: function (id, row) {
        this.profileSectionsId = id;
        var diameter = row.find('.PcProfileSections_selectItems_2').html();
        var thickness = row.find('.PcProfileSections_selectItems_3').html();
        var square = row.find('.PcProfileSections_selectItems_4').html();
        $('#txtDiameter').val(diameter);
        $('#txtThickness').val(thickness);
        $('#txtSquare').val(square);
        contentPicker.verificationData();
    },

    pcProfileSectionsClick: function (contentId) {
        if (this.materialId == -1) {
            alert("Ви не вибрали матеріал");
            $("#PcProfileSections_contentPicker_textbox").val("");
        } else {
            contentId.fadeToggle();
        }
    },

    pcTypeSoilsSelected: function (id) {
        this.typeSoilsId = id;
        contentPicker.verificationData();
    },
    pcResistivitySoils: function (id, row) {
        this.resistivitySoilsId = id;
        this._soilIdForResistivitySoil = row.find('.PcResistivitySoils_selectItems_1').html();
        contentPicker.verificationData();
    },
    pcFirstTypeElectrodeSelected: function (id) {
        this.firstTypeElectrodeId = id;
        contentPicker.verificationData();
    },
    pcSecondTypeElectrodeSelected: function (id) {
        this.secondTypeElectrodeId = id;
        contentPicker.verificationData();
    },
    pcFirstLengthElectrodeSelected: function (id) {
        this.firstLengthElectrodeId = id;
        contentPicker.verificationData();
    },
    pcSecondLengthElectrodeSelected: function (id) {
        this.secondLengthElectrodeId = id;
        contentPicker.verificationData();
    },
    pcHeaven: function (id) {
        this.heavenId = id;
        contentPicker.verificationData();
    },
    pcHumidity: function (id) {
        this.humidityId = id;
        contentPicker.verificationData();
    },
    pcFirstGroundItemType: function (id) {
        this.firstGroundItemTypeId = id;
        contentPicker.verificationData();
    },
    pcSecondGroundItemType: function (id) {
        this.secondGroundItemTypeId = id;
        contentPicker.verificationData();
    },
    pcFirstFormula: function (id) {
        this.firstFormulaId = id;
        contentPicker.verificationData();
    },
    pcSecondFormula: function (id) {
        this.secondFormulaId = id;
        contentPicker.verificationData();
    },
}



