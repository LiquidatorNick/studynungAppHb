"undefined" == typeof contentPicker && (contentPicker = {});
"undefined" == typeof logManager && (logManager = {});
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
        this.isCanCalcKcVertical = false;
        this.isCanCalcKcHoriz = false;
        this.isFirstFormulaChosen = false;
        this.isSecondFormulaChosen = false;
        this.isFirstFormulaValid = false;
        this.isSecondFormulaValid = false;
        this.isCanFirstCalc = false;
        this.isCanSecondCalc = false;
        this.isResistivitySoilInsert = false;

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
            FirstGroundItemTypeId: this.firstGroundItemTypeId,
            SecondGroundItemTypeId: this.secondGroundItemTypeId,
            FirstFormulaId: this.firstFormulaId,
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
        contentPicker._toLog();
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
            var kcHoriz = fieldsManager.KcMatrix['1' + this.heavenId + this.humidityId + this.firstLengthElectrodeId];
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
        if (this.isCanFirstCalc) {
            var fieldsHoriz = new TempFields(fieldsManager.t, fieldsManager.Lhoriz, fieldsManager.Lvert, fieldsManager.t0, fieldsManager.KcVertical,
                fieldsManager.d, fieldsManager.D, fieldsManager.a, fieldsManager.b);
            var resultHoriz = formulas.calculate(this.SecondFormulaId, fieldsHoriz);
            fieldsManager.Rhoriz = resultHoriz;
        }
    },
    _toLog: function () {
        logManager.clear();
        if (fieldsManager.Rdop != NaN) {
            logManager.appendLine("Допустимий опір: " + fieldsManager.Rdop + " Ом");
        }
        if (this.isCanCalcKcVertical && fieldsManager.KcVertical != NaN) {
            logManager.appendLine("Коефіцієнт сезонності(верт.): " + fieldsManager.KcVertical);
        }
        if (this.isCanCalcKcHoriz && fieldsManager.KcHoriz != NaN) {
            logManager.appendLine("Коефіцієнт сезонності(гориз.): " + fieldsManager.KcHoriz);
        }
        if (this.isShowVerticalRor && fieldsManager.RorVert != NaN) {
            logManager.appendLine("Розрахункове значення питомого опору грунту рівне(верт.): " + fieldsManager.RorVert);
        }
        if (this.isShowHorizRor && fieldsManager.RorHoriz != NaN) {
            logManager.appendLine("Розрахункове значення питомого опору грунту рівне(гориз.): " + fieldsManager.RorHoriz);
        }
        if (fieldsManager.Rvert != NaN) {
            logManager.appendLine("Результат розрахунку опору розтіканню струму: " + fieldsManager.Rvert);
        }
        logManager.show();
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
        var d = 0.5 * fields.d;
        var t = fields.t0;
        return (fields.Ror / (2 * Math.PI * fields.firstL)) * Math.Log(Math.Pow(fields.firstL, 2) / (d * t));
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
    }
}