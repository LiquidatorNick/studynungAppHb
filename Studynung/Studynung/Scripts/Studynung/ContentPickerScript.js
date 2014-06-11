"undefined" == typeof contentPicker && (contentPicker = {});
"undefined" == typeof logManager && (logManager = {});
contentPicker = {
    init: function () {
        this.resultsId = $("#labsResultId").val();

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
        this.ratioDistanceWithLength = -1;

        // Verification items
        this.isGroupGrounding = false;
        this.isMaterialSelected = false;
        this.isCanLoadProfileSections = false;
        this.isSoilValueValid = false;
        this.isSoilDataInsert = false;
        this.isCanCalcKcVertical = false;
        this.isCanCalcKcHoriz = false;
        this.isFirstFormulaChosen = false;
        this.isSecondFormulaChosen = false;
        this.isFirstFormulaValid = false;
        this.isSecondFormulaValid = false;
        this.isCanFirstCalc = false;
        this.isCanSecondCalc = false;
        this.isResistivitySoilInsert = false;
        this.isContinue = false;

        // show properties
        this.isShowVerticalRor = false;
        this.isShowHorizRor = false;

        // private fields
        this._soilIdForResistivitySoil = -1;

        // init methods
        logManager.init("#area-result");
        fieldsManager.init();
        $(".tableHaracteristic-tr").click(function () {
            var value = $(this).find('td:last').html();
            if (value.length > 3) {
                $("#PcHaracteristic_contentPicker_textbox").val('Введіть значення Із');
                $('#hiddenIz').val(value);
                $('#divIz').fadeIn();
            } else {
                $('#divIz').fadeOut();
                $("#PcHaracteristic_contentPicker_textbox").val(value);
                fieldsManager.Rdop = value;
                $('.tableHaracteristic-tr').css({ 'background': 'transparent', 'color': 'black' });
                $(this).css({ 'background': '#3399FF', 'color': 'white' });
            }
            $("#tableHaracteristic").fadeToggle();
            contentPicker.verificationData();
        });
        $("#PcHaracteristic_btnselect").click(function () {
            $("#tableHaracteristic").fadeToggle();
        });
        $('#btnIzSubmit').click(function () {
            var value = $("#hiddenIz").val();
            var iz = $("#txtIz").val();
            var result = 0;
            if (value.indexOf('125') != -1) {
                result = 125 / iz;
            } else if (value.indexOf('250') != -1) {
                result = 250 / iz;
            }
            if (result > 10) {
                alert('Значення не може перевищувати 10 Ом, тому приймаємо значення Rдоп = 10 Oм.');
                result = 10;
            }
            fieldsManager.Rdop = result;
            $('#divIz').fadeOut();
            $("#PcHaracteristic_contentPicker_textbox").val(result + " Ом");
        });
        $('#txtT0').blur(function () {
            fieldsManager.t0 = parseFloat($(this).val());
            contentPicker.verificationData();
        });
    },

    verificationData: function () {
        contentPicker._verifyIds();
        contentPicker._applyVerify();
        contentPicker._toLog();
        contentPicker._saveChanges();
    },
    _verifyIds: function () {
        this.isGroupGrounding = this.countGroundingId == 1;
        this.isMaterialSelected = this.materialId != -1;
        this.isSoilDataInsert = this.typeSoilsId != -1 && this.resistivitySoilsId != -1;
        this.isSoilValueValid = this.isSoilDataInsert && $.inArray(this.typeSoilsId, this._soilIdForResistivitySoil.split(';')) != -1;
        this.isCanCalcKcVertical = this.firstTypeElectrodeId != -1 && this.firstLengthElectrodeId != -1 && this.heavenId != -1 && this.humidityId != -1;
        this.isCanCalcKcHoriz = this.secondTypeElectrodeId != -1 && this.secondLengthElectrodeId != -1 && this.heavenId != -1 && this.humidityId != -1;
        this.isFirstFormulaChosen = this.firstFormulaId != -1 && this.firstGroundItemTypeId != -1;
        this.isSecondFormulaChosen = this.secondFormulaId != -1 && this.secondGroundItemTypeId != -1;
        this.isFirstFormulaValid = this.firstFormulaId == this.firstGroundItemTypeId;
        this.isSecondFormulaValid = this.secondFormulaId == this.secondGroundItemTypeId;
        this.isCanFirstCalc = this.isFirstFormulaChosen && this.isFirstFormulaValid;
        this.isCanSecondCalc = this.isSecondFormulaChosen && this.isSecondFormulaValid;
    },
    _applyVerify: function () {
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
        if (this.isFirstFormulaChosen && !this.isFirstFormulaValid) {
            alert("Дана формула не підходить для для вибраного способу розміщення електродів заземлювача");
            this.firstFormulaId = -1;
            $("#PcFirstFormula_contentPicker_textbox").val('');
        }
        if (this.isSecondFormulaChosen && !this.isSecondFormulaValid) {
            alert("Дана формула не підходить для для вибраного способу розміщення електродів заземлювача");
            this.secondFormulaId = -1;
            $("#PcSecondFormula_contentPicker_textbox").val('');
        }
        if (this.isCanCalcKcVertical) {
            var kcVert = fieldsManager.KcMatrix['0' + this.heavenId + this.humidityId + this.firstLengthElectrodeId];
            fieldsManager.KcVertical = kcVert;
            //logManager.appendLine("Коефіцієнт сезонності(верт.): " + kcVert);
        }
        if (this.isCanCalcKcHoriz) {
            var kcHoriz = fieldsManager.KcMatrix['1' + this.heavenId + this.humidityId + this.secondLengthElectrodeId];
            fieldsManager.KcHoriz = kcHoriz;
            //logManager.appendLine("Коефіцієнт сезонності(гориз.): " + kcHoriz);
        }
        if (this.isSoilValueValid && this.isSoilDataInsert && this.isCanCalcKcVertical) {
            var resultValue = formulas.calculateValueResistivitySoil(fieldsManager.Rovym, fieldsManager.KcVertical);
            fieldsManager.RorVert = resultValue;
            this.isShowVerticalRor = true;

        } else {
            this.isShowVerticalRor = false;
        }
        if (this.isSoilValueValid && this.isSoilDataInsert && this.isCanCalcKcHoriz) {
            var resultValue = formulas.calculateValueResistivitySoil(fieldsManager.Rovym, fieldsManager.KcHoriz);
            fieldsManager.RorHoriz = resultValue;
            this.isShowHorizRor = true;

        } else {
            this.isShowHorizRor = false;
        }
        if (this.isCanFirstCalc) {
            fieldsManager.t = formulas.calculate_t(parseFloat(fieldsManager.t0), parseFloat(fieldsManager.Lvert));
            var fields = new TempFields(parseFloat(fieldsManager.t), parseFloat(fieldsManager.Lvert), parseFloat(fieldsManager.Lvert),
                parseFloat(fieldsManager.t0), parseFloat(fieldsManager.RorVert), parseFloat(fieldsManager.d) / 1000, parseFloat(fieldsManager.D),
                parseFloat(fieldsManager.a), parseFloat(fieldsManager.b));
            var resultVert = formulas.calculate(this.firstFormulaId, fields);
            if (resultVert != 'none') {
                fieldsManager.Rvert = resultVert;
            }
        }
        if (this.isCanSecondCalc) {
            fieldsManager.t = formulas.calculate_t(parseFloat(fieldsManager.t0), parseFloat(fieldsManager.Lvert));
            var fieldsHoriz = new TempFields(parseFloat(fieldsManager.t), parseFloat(fieldsManager.Lhoriz), parseFloat(fieldsManager.Lvert),
                parseFloat(fieldsManager.t0), parseFloat(fieldsManager.RorHoriz), parseFloat(fieldsManager.d) / 1000,
                parseFloat(fieldsManager.D), parseFloat(fieldsManager.a), parseFloat(fieldsManager.b));
            var resultHoriz = formulas.calculate(this.secondFormulaId, fieldsHoriz);
            fieldsManager.Rhoriz = resultHoriz;
        }
        if (!isNaN(fieldsManager.Rvert) || !isNaN(fieldsManager.Rhoriz)) {
            if (fieldsManager.Rvert > fieldsManager.Rdop || fieldsManager.Rhoriz > fieldsManager.Rdop) {
                this.isContinue = true;
                this.continueToCompute();
            }
        } else {
            this.isContinue = false;
        }
        if (this.isContinue) {
            $("#div-continue").fadeIn();
        } else {
            $("#div-continue").fadeOut();
        }
    },
    _toLog: function () {
        logManager.clear();
        if (!isNaN(fieldsManager.Rdop)) {
            logManager.appendLine("Допустимий опір: " + fieldsManager.Rdop + " Ом");
        }
        if (this.isCanCalcKcVertical && !isNaN(fieldsManager.KcVertical)) {
            logManager.appendLine("Коефіцієнт сезонності(верт.): " + fieldsManager.KcVertical);
        }
        if (this.isCanCalcKcHoriz && !isNaN(fieldsManager.KcHoriz)) {
            logManager.appendLine("Коефіцієнт сезонності(гориз.): " + fieldsManager.KcHoriz);
        }
        if (this.isShowVerticalRor && !isNaN(fieldsManager.RorVert)) {
            logManager.appendLine("Розрахункове значення питомого опору ґрунту рівне(верт.): " + fieldsManager.RorVert);
        }
        if (this.isShowHorizRor && !isNaN(fieldsManager.RorHoriz)) {
            logManager.appendLine("Розрахункове значення питомого опору ґрунту рівне(гориз.): " + fieldsManager.RorHoriz);
        }
        if (!isNaN(fieldsManager.Rvert)) {
            logManager.appendLine("Результат розрахунку опору розтіканню струму(верт.): " + fieldsManager.Rvert);
        }
        if (!isNaN(fieldsManager.Rhoriz)) {
            logManager.appendLine("Результат розрахунку опору розтіканню струму(гориз.): " + fieldsManager.Rhoriz);
        }
        if (!isNaN(fieldsManager.Rvert) || !isNaN(fieldsManager.Rhoriz)) {
            if (fieldsManager.Rvert > fieldsManager.Rdop || fieldsManager.Rhoriz > fieldsManager.Rdop) {
                logManager.appendLine("Значення R є більшим за допустиме");
            } else {
                alert("Значення R в межах норми.");
                logManager.appendLine("Значення R в межах норми");
            }
        }
        if (this.isContinue) {
            logManager.appendLine("Рекомендована кількість електродів: " + fieldsManager.countElectrodesWithoutNude);
            if (!isNaN(fieldsManager.nudeVert)) {
                logManager.appendLine("η(верт.): " + fieldsManager.nudeVert);
            }
            logManager.appendLine("Рекомендована кількість електродів з врахуванням η: " + fieldsManager.countElectrodesWithNude);
            if (!isNaN(fieldsManager.Rz))
                logManager.appendLine("Rз: " + fieldsManager.Rz);
        }
        logManager.show();
    },
    _saveChanges: function () {
        var items = {
            Id : this.resultsId,
            CountGroundingId: this.countGroundingId,
            FirstPlacementElectrodesId: this.firstPlacementElectrodesId,
            GroundDeviceTypeId: this.groundDeviceTypeId,
            LocationElectrodesId: this.locationElectrodesId,
            MaterialId: this.materialId,
            ProfileSectionsId: this.profileSectionsId,
            TypeSoilsId: this.typeSoilsId,
            ResistivitySoilsId: this.resistivitySoilsId,
            FirstTypeElectrodeId: this.firstTypeElectrodeId,
            SecondTypeElectrodeId: this.secondTypeElectrodeId,
            FirstLengthElectrodeId: this.firstLengthElectrodeId,
            SecondLengthElectrodeId: this.secondLengthElectrodeId,
            HeavenId: this.heavenId,
            HumidityId: this.humidityId,
            FirstGroundItemTypeId: this.firstGroundItemTypeId,
            SecondGroundItemTypeId: this.secondGroundItemTypeId,
            FirstFormulaId: this.firstFormulaId,
            SecondFormulaId: this.secondFormulaId,
            RatioDistanceWithLength: this.ratioDistanceWithLength,

            ValueRdop: fieldsManager.Rdop.toString(),
            ValueLvert: fieldsManager.Lvert.toString(),
            ValueLhoriz: fieldsManager.Lhoriz.toString(),
            ValueKcVertical: fieldsManager.KcVertical.toString(),
            ValueKcHoriz: fieldsManager.KcHoriz.toString(),
            ValueRovym: fieldsManager.Rovym.toString(),
            Valuea: fieldsManager.a.toString(),
            Valueb: fieldsManager.b.toString(),
            Valuet: fieldsManager.t.toString(),
            Valuet0: fieldsManager.t0.toString(),
            Valued: fieldsManager.d.toString(),
            ValueDUpper: fieldsManager.D.toString(),
            ValueRorVert: fieldsManager.RorVert.toString(),
            ValueRorHoriz: fieldsManager.RorHoriz.toString(),
            ValueRvert: fieldsManager.Rvert.toString(),
            ValueRhoriz: fieldsManager.Rhoriz.toString(),
            ValueRz: fieldsManager.Rz.toString(),
            ValuecountElectrodes: fieldsManager.countElectrodes.toString(),
            ValuecountElectrodesWithoutNude: fieldsManager.countElectrodesWithoutNude.toString(),
            ValuecountElectrodesWithNude: fieldsManager.countElectrodesWithNude.toString(),
            ValuenudeVert: fieldsManager.nudeVert.toString(),
            ValuenudeHoriz: fieldsManager.nudeHoriz.toString(),
            ValueratioDistanceWithLength: fieldsManager.ratioDistanceWithLength.toString(),

            Results: logManager.getText(),
            Errors: logManager.getText()
        };

        $.ajax({
            url: '/ProtectiveEarthing/SaveChanges',
            type: 'POST',
            cache: false,
            dataType: "html",
            data: items,
            success: function () {
            }
        });
    },

    continueToCompute: function () {

        var countElectrodes = Math.ceil(fieldsManager.Rvert / fieldsManager.Rdop);
        fieldsManager.countElectrodes = countElectrodes;
        fieldsManager.countElectrodesWithoutNude = countElectrodes;
        var firstNude = utilizationEarthing.findNude(this.firstPlacementElectrodesId, countElectrodes, this.ratioDistanceWithLength);
        fieldsManager.nudeVert = firstNude;
        // Обчислення n(штріх) ------------------------------------------------------------------------------------

        var countElectrodesWithNude = formulas.calculateCountElectrodesWithNude(fieldsManager.Rvert,
                fieldsManager.Rdop, fieldsManager.nudeVert);
        fieldsManager.countElectrodesWithNude = countElectrodesWithNude;
        fieldsManager.countElectrodes = countElectrodesWithNude;
        // --------------------------------------------------------------------------------------------------------

        // Refresh firstnude --------------------------------------------------------------------------------------
        fieldsManager.nudeVert = utilizationEarthing.findNude(this.firstPlacementElectrodesId, fieldsManager.countElectrodes,
            this.ratioDistanceWithLength);
        //---------------------------------------------------------------------------------------------------------

        // Знаходження Rрозр.в. -----------------------------------------------------------------------------------
        var Rvert = fieldsManager.Rvert / (fieldsManager.countElectrodesWithNude * fieldsManager.nudeVert);
        // --------------------------------------------------------------------------------------------------------

        // Довжина горизонтальних електродів для умови комбінованого заземлення -----------------------------------
        var k = fieldsManager.ratioDistanceWithLength;
        var a = k * fieldsManager.Lvert;
        var L = this.firstPlacementElectrodesId == 1
            ? (fieldsManager.countElectrodes * a)
            : (a * (fieldsManager.countElectrodes - 1));
        fieldsManager.Lhoriz = L;
        // --------------------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------------------
        var isOnRow = this.firstPlacementElectrodesId == 0;
        // Знаходження Rрозр.г. -----------------------------------------------------------------------------------
        fieldsManager.nudeHoriz = utilizationEarthing.findNude(2, fieldsManager.countElectrodes, this.ratioDistanceWithLength, isOnRow);
        var Rhoriz = fieldsManager.Rhoriz / fieldsManager.nudeHoriz;
        // --------------------------------------------------------------------------------------------------------

        // --------------------------------------------------------------------------------------------------------
        var Rz = (Rvert * Rhoriz) / (Rvert + Rhoriz);
        fieldsManager.Rz = Rz;
        //_log.Rz = string.Format("Rz: {0}", Math.Round(Rz, 2));
        // --------------------------------------------------------------------------------------------------------
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
        this.profileSectionsId = -1;
        $("#PcProfileSections_contentPicker_textbox").val('');
        $('#txtDiameter').val('');
        $('#txtThickness').val('');
        $('#txtSquare').val("");
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
        //var diameter = row.find('.PcProfileSections_selectItems_2').html();
        //var thickness = row.find('.PcProfileSections_selectItems_3').html();
        //var square = row.find('.PcProfileSections_selectItems_4').html();
        fieldsManager.d = row.find('.PcProfileSections_selectItems_2').html();
        fieldsManager.a = row.find('.PcProfileSections_selectItems_3').html();
        fieldsManager.b = row.find('.PcProfileSections_selectItems_4').html();
        $('#txtDiameter').val(row.find('.PcProfileSections_selectItems_5').html());
        $('#txtThickness').val(row.find('.PcProfileSections_selectItems_6').html());
        $('#txtSquare').val(row.find('.PcProfileSections_selectItems_7').html());
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
        //alert(parseFloat(row.find('.PcResistivitySoils_selectItems_0').html()));
        fieldsManager.Rovym = parseFloat(row.find('.PcResistivitySoils_selectItems_0').html());
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
        fieldsManager.Lvert = $("#PcFirstLengthElectrode_contentPicker_textbox").val();
        contentPicker.verificationData();
    },
    pcSecondLengthElectrodeSelected: function (id) {
        this.secondLengthElectrodeId = id;
        fieldsManager.Lhoriz = $("#PcSecondLengthElectrode_contentPicker_textbox").val();
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
    pcRatioDistanceWithLengthSelected: function (id) {
        this.ratioDistanceWithLength = id;
        if (id != -1) {
            fieldsManager.ratioDistanceWithLength = parseInt(id) + 1;
        }
        contentPicker.verificationData();
    }
}

logManager = {
    init: function (id) {
        this.resultContentId = id;
        this.text = '';
    },
    clear: function () {
        this.text = '';
    },
    appendLine: function (str) {
        this.text = this.text + str + "\n";
    },
    show: function () {
        $(this.resultContentId).val(this.text);
    },
    getText: function () {
        return this.text;
    }
}

fieldsManager = {
    Rdop: NaN,
    Lvert: NaN,
    Lhoriz: NaN,
    KcVertical: NaN,
    KcHoriz: NaN,
    Rovym: NaN,
    a: NaN,
    b: NaN,
    t: NaN,
    t0: NaN,
    d: NaN,
    D: NaN,
    RorVert: NaN,
    RorHoriz: NaN,
    Rvert: NaN,
    Rhoriz: NaN,
    Rz: NaN,
    countElectrodes: NaN,
    countElectrodesWithoutNude: NaN,
    countElectrodesWithNude: NaN,
    nudeVert: NaN,
    nudeHoriz: NaN,
    ratioDistanceWithLength: NaN,
    KcMatrix: {
        "0000": 1.9,
        "0001": 1.5,
        "0010": 1.7,
        "0011": 1.4,
        "0020": 1.5,
        "0021": 1.3,
        "0100": 1.7,
        "0101": 1.4,
        "0110": 1.5,
        "0111": 1.3,
        "0120": 1.3,
        "0121": 1.2,
        "0200": 1.5,
        "0201": 1.3,
        "0210": 1.3,
        "0211": 1.2,
        "0220": 1.2,
        "0221": 1.1,
        "0300": 1.3,
        "0301": 1.2,
        "0310": 1.1,
        "0311": 1.1,
        "0320": 1.0,
        "0321": 1.0,

        "1000": 9.3,
        "1001": 7.2,
        "1010": 5.5,
        "1011": 4.5,
        "1020": 4.1,
        "1021": 3.6,
        "1100": 5.9,
        "1101": 4.8,
        "1110": 3.5,
        "1111": 3.0,
        "1120": 2.5,
        "1121": 2.4,
        "1200": 4.0,
        "1201": 3.2,
        "1210": 2.5,
        "1211": 2.0,
        "1220": 2.0,
        "1221": 1.6,
        "1300": 2.5,
        "1301": 2.2,
        "1310": 1.5,
        "1311": 1.4,
        "1320": 1.1,
        "1321": 1.12
    },
    init: function () {

    }
}

function TempFields(t, L, firstL, t0, Ror, d, D, a, b) {
    this.t = t;
    this.L = L;
    this.firstL = firstL;
    this.t0 = t0;
    this.Ror = Ror;
    this.d = d;
    this.D = D;
    this.a = a;
    this.b = b;
}

formulas = {
    calculate: function (formulaId, tempFields) {
        var result = 0;
        switch (parseInt(formulaId)) {
            case 0:
                result = formulas.firstFormula(tempFields);
                break;
            case 1:
                result = formulas.secondFormula(tempFields);
                break;
            case 2:
                result = formulas.thirdFormula(tempFields);
                break;
            case 3:
                result = formulas.fourFormula(tempFields);
                break;
            case 4:
                result = formulas.fiveFormula(tempFields);
                break;
            case 5:
                result = formulas.sixthFormula(tempFields);
                break;
            case 6:
                result = formulas.sevenFormula(tempFields);
                break;
            case 7:
                result = formulas.eighthFormula(tempFields);
                break;
            case 8:
                result = formulas.ninthFormula(tempFields);
                break;
            case 9:
                result = formulas.tenthFormula(tempFields);
                break;
            case 10:
                result = formulas.eleventhFormula(tempFields);
                break;
            case 11:
                result = formulas.twelfthFormula(tempFields);
                break;
        }
        return result;
    },

    firstFormula: function (fields) {
        var d = 0.95 * fields.b;
        return (fields.Ror / (2 * Math.PI * fields.L)) * Math.Log((4 * fields.L) / d);
    },

    secondFormula: function (fields) {
        if (fields.d != NaN && fields.Ror != NaN && fields.L != NaN && fields.t != NaN) {
            var d = fields.d;
            var first = (fields.Ror / (2 * Math.PI * fields.L));
            var second = (2 * fields.L) / d;
            var third = Math.log(second);
            var four = (4 * fields.t + fields.L) / (4 * fields.t - fields.L);
            var five = Math.log(four);
            var six = .5 * five;
            var seven = third + six;
            var eight = first * seven;
            return (fields.Ror / (2 * Math.PI * fields.L)) *
                (Math.log((2 * fields.L) / d) + .5 *
                Math.log((4 * fields.t + fields.L) / (4 * fields.t - fields.L)));
        } else {
            return 'none';
        }
    },

    thirdFormula: function (fields) {
        var d = 0.5 * fields.b;
        return (fields.Ror / (Math.PI * fields.L)) * Math.Log((2 * fields.L) / d);
    },

    fourFormula: function (fields) {
        try {
            var d = 0.5 * fields.d;
            var t = fields.t;
            return (fields.Ror / (2 * Math.PI * fields.firstL)) * Math.log(Math.pow(fields.firstL, 2) / (d * t));
        } catch (e) {
            return NaN;
        }
    },

    fiveFormula: function (fields) {
        return (fields.Ror / (Math.PI * fields.a)) * Math.Log((4 * fields.a) / fields.b);
    },

    sixthFormula: function (fields) {
        return (fields.Ror / (2 * Math.PI * fields.a)) * (Math.Log((4 * fields.a) / fields.b) + (fields.a / (4 * fields.t0)));
    },

    sevenFormula: function (fields) {
        return fields.Ror / (2 * fields.D);
    },

    eighthFormula: function (fields) {
        return (fields.Ror / (4 * fields.D)) * (1 + (2 / Math.PI) * Math.Asin(fields.D / (Math.Sqrt(16 * Math.Pow(fields.t0, 2) + Math.Pow(fields.D, 2)))));
    },

    ninthFormula: function (fields) {
        return (fields.Ror / (4 * Math.PI * fields.D)) * (1 + (fields.D / (4 * fields.t)));
    },

    tenthFormula: function (fields) {
        return (fields.Ror / (Math.PI * fields.D));
    },

    eleventhFormula: function (fields) {
        return (fields.Ror / (Math.Pow(Math.PI, 2) * fields.D)) * Math.Log((8 * fields.D) / fields.d);
    },

    twelfthFormula: function (fields) {
        return (fields.Ror / (2 * Math.Pow(Math.PI, 2) * fields.D)) * Math.Log((4 * Math.PI * Math.Pow(fields.D, 2)) / (fields.d * fields.t));
    },

    calculateValueResistivitySoil: function (rovym, kc) {
        return rovym * kc;
    },

    calculate_t: function (t0, l) {
        if (t0 == -1)
            return NaN;
        return t0 + (l / 2);
    },

    calculateCountElectrodesWithNude: function (Rv, Rdop, nude) {
        return Math.ceil(Rv / (Rdop * nude));
    }
},

utilizationEarthing = {
    findNude: function (placementElectrodeId, countElectrodes, ratioDWLId, isOnRow) {
        if (placementElectrodeId != -1 && countElectrodes != -1 && ratioDWLId != -1)
            if (placementElectrodeId == 2) {
                if (isOnRow != null)
                    return utilizationEarthing.FindNudeHoriz(countElectrodes, ratioDWLId, isOnRow);
            }
            else {
                return utilizationEarthing.FindFromTableSix(placementElectrodeId, countElectrodes, ratioDWLId);
            }
        return NaN;
    },
    FindFromTableSix: function (placementElectrodeId, countElectrodes, ratioDWLId) {
        var idCE = utilizationEarthing.GetCountElectrodesId(countElectrodes);
        if (placementElectrodeId == 0) {
            return utilizationEarthing.TableSixPartOne(idCE, ratioDWLId);
        }
        else {
            return utilizationEarthing.TableSixPartTwo(idCE, ratioDWLId);
        }
    },
    GetCountElectrodesId: function (countElectrodes) {
        if (countElectrodes == 2) {
            return 0;
        }
        else if (countElectrodes == 3) {
            return 1;
        }
        else if (countElectrodes == 4) {
            return 2;
        }
        else if (countElectrodes == 5) {
            return 3;
        }
        else if (countElectrodes >= 6 && countElectrodes < 10) {
            return 4;
        }
        else if (countElectrodes >= 10 && countElectrodes < 15) {
            return 5;
        }
        else if (countElectrodes >= 15 && countElectrodes < 20) {
            return 6;
        }
        else if (countElectrodes >= 20 && countElectrodes < 40) {
            return 7;
        }
        else if (countElectrodes >= 40 && countElectrodes < 60) {
            return 8;
        }
        else if (countElectrodes >= 60 && countElectrodes < 100) {
            return 9;
        }
        else if (countElectrodes == 100) {
            return 10;
        }
        return -1;
    },
    FindNudeHoriz: function (countElectrodes, ratioDWLId, isOnRow) {
        var idCE = utilizationEarthing.GetCountElectrodesIdFromHoriz(countElectrodes);
        return isOnRow ? utilizationEarthing.TableHorizOnRow(ratioDWLId, idCE) : utilizationEarthing.TableHorizOnContour(ratioDWLId, idCE);
    },
    GetCountElectrodesIdFromHoriz: function (countElectrodes) {
        if (countElectrodes >= 2 && countElectrodes < 4) {
            return 0;
        }
        else if (countElectrodes == 4) {
            return 1;
        }
        else if (countElectrodes == 5) {
            return 2;
        }
        else if (countElectrodes >= 6 && countElectrodes < 8) {
            return 3;
        }
        else if (countElectrodes >= 8 && countElectrodes < 10) {
            return 4;
        }
        else if (countElectrodes >= 10 && countElectrodes < 20) {
            return 5;
        }
        else if (countElectrodes >= 20 && countElectrodes < 30) {
            return 6;
        }
        else if (countElectrodes >= 30 && countElectrodes < 40) {
            return 7;
        }
        else if (countElectrodes >= 40 && countElectrodes < 50) {
            return 8;
        }
        else if (countElectrodes >= 50 && countElectrodes < 60) {
            return 9;
        }
        else if (countElectrodes >= 60 && countElectrodes < 70) {
            return 10;
        }
        else if (countElectrodes >= 70 && countElectrodes < 100) {
            return 11;
        }
        else if (countElectrodes == 100) {
            return 12;
        }
        return -1;
    },
    TableSixPartOne: function (i, j) {
        var matrix = {
            "00": 0.85,
            "01": 0.91,
            "02": 0.94,
            "10": 0.78,
            "11": 0.87,
            "12": 0.91,
            "20": 0.73,
            "21": 0.83,
            "22": 0.89,
            "30": 0.70,
            "31": 0.81,
            "32": 0.87,
            "40": 0.65,
            "41": 0.77,
            "42": 0.85,
            "50": 0.59,
            "51": 0.74,
            "52": 0.81,
            "60": 0.54,
            "61": 0.70,
            "62": 0.78,
            "70": 0.48,
            "71": 0.67,
            "72": 0.76,
            "80": NaN,
            "81": NaN,
            "82": NaN,
            "90": NaN,
            "91": NaN,
            "92": NaN,
            "100": NaN,
            "101": NaN,
            "102": NaN
        }
        return matrix[i + j + ""];
    },
    TableSixPartTwo: function (i, j) {
        var matrix = {
            "00": NaN,
            "01": NaN,
            "02": NaN,
            "10": NaN,
            "11": NaN,
            "12": NaN,
            "20": 0.69,
            "21": 0.78,
            "22": 0.85,
            "30": NaN,
            "31": NaN,
            "32": NaN,
            "40": 0.61,
            "41": 0.73,
            "42": 0.80,
            "50": 0.56,
            "51": 0.68,
            "52": 0.76,
            "60": NaN,
            "61": NaN,
            "62": NaN,
            "70": 0.47,
            "71": 0.63,
            "72": 0.72,
            "80": 0.41,
            "81": 0.58,
            "82": 0.66,
            "90": 0.39,
            "91": 0.55,
            "92": 0.64,
            "100": 0.36,
            "101": 0.52,
            "102": 0.62
        }
        return matrix[i + j + ""];
    },
    TableHorizOnRow: function (i, j) {
        var matrix = {
            "00": 0.85,
            "01": 0.94,
            "02": 0.96,
            "10": 0.77,
            "11": 0.89,
            "12": 0.92,
            "20": 0.74,
            "21": 0.86,
            "22": 0.90,
            "30": 0.72,
            "31": 0.84,
            "32": 0.88,
            "40": 0.67,
            "41": 0.79,
            "42": 0.85,
            "50": 0.62,
            "51": 0.75,
            "52": 0.82,
            "60": 0.42,
            "61": 0.56,
            "62": 0.68,
            "70": 0.31,
            "71": 0.46,
            "72": 0.58,
            "80": NaN,
            "81": NaN,
            "82": NaN,
            "90": 0.21,
            "91": 0.36,
            "92": 0.49,
            "100": NaN,
            "101": NaN,
            "102": NaN,
            "110": NaN,
            "111": NaN,
            "112": NaN,
            "120": NaN,
            "121": NaN,
            "122": NaN
        }
        return matrix[j + i];
    },
    TableHorizOnContour: function (i, j) {
        var matrix = {
            "00": NaN,
            "01": NaN,
            "02": NaN,
            "10": 0.45,
            "11": 0.55,
            "12": 0.70,
            "20": NaN,
            "21": NaN,
            "22": NaN,

            "30": 0.40,
            "31": 0.48,
            "32": 0.64,
            "40": 0.36,
            "41": 0.43,
            "42": 0.60,
            "50": 0.34,
            "51": 0.40,
            "52": 0.56,
            "60": 0.27,
            "61": 0.32,
            "62": 0.45,
            "70": 0.24,
            "71": 0.30,
            "72": 0.41,
            "80": 0.22,
            "81": 0.29,
            "82": 0.39,
            "90": 0.21,
            "91": 0.28,
            "92": 0.37,
            "100": 0.20,
            "101": 0.27,
            "102": 0.36,
            "110": 0.20,
            "111": 0.26,
            "112": 0.35,
            "120": 0.19,
            "121": 0.23,
            "122": 0.33
        }
        return matrix[i + j];
    }
}

