using System;
using System.Collections.Generic;
using System.IO;
using Studynung.ProtectiveEarthing.Items;
using Studynung.ProtectiveEarthing.Logic.Items;

namespace Studynung.ProtectiveEarthing.Logic
{
    public partial class BaseData
    {
        public BaseData()
        {
            InitCountGrounding();
            InitPlacementElectrodes();
            InitGroundDeviceTypeData();
            InitLocationElectrodes();
            InitMaterials();
            InitProfileSections();
            InitSoils();
            InitResistivitySoils();
            InitTypeElectrode();
            InitVerticalLengthElectrode();
            InitHorizontalLengthElectrode();
            InitHeaven();
            InitHumidity();
            InitGroundItems();
        }

        protected void InitCountGrounding()
        {
            CountGrounding = new[]
            {
                new BaseItem(){Id = 0, Name = "Одиночний"}, 
                new BaseItem(){Id = 1, Name = "Груповий"}
            };
        }

        private void InitPlacementElectrodes()
        {
            PlacementElectrodes = new BaseItemWithImage[]
            {
                new BaseItemWithImage()
                {
                    Id = 0, 
                    Name = "Вертикальні електроди розміщені у ряд",
                    ImgSource = string.Format("<img src='../../Content/Images/Grounding/GroundingType0.png'></img>")
                }, 
                new BaseItemWithImage()
                {
                    Id = 1, 
                    Name = "Вертикальні електроди розміщені по контуру",
                    ImgSource = string.Format("<img src='../../Content/Images/Grounding/GroundingType1.png'></img>")
                }, 
                new BaseItemWithImage()
                {
                    Id = 2, 
                    Name = "горизонтальні електроди покладені паралельно на однаковій глибині",
                    ImgSource = string.Format("<img src='../../Content/Images/Grounding/GroundingType2.png'></img>")
                }
            };
        }

        protected void InitGroundDeviceTypeData()
        {
            GroundDeviceTypes = new[]
            {
                new BaseItemWithImage()
                {
                    Id = 0,
                    Name = "Виносний",
                    ImgSource = string.Format("<img src='../../Content/Images/Grounding/Vynosne.png'></img>")
                },
                new BaseItemWithImage()
                {
                    Id = 1,
                    Name = "Контурний",
                    ImgSource = string.Format("<img src='../../Content/Images/Grounding/konturne.png'></img>")
                }
            };
        }

        private void InitLocationElectrodes()
        {
            LocationElectrodes = new[]
            {
                new LocationItem() {Id = 0, Name = "В ґрунті", ValidFormulas = new[] {1, 3, 5, 7, 8, 11}},
                new LocationItem() {Id = 1, Name = "Біля поверхні", ValidFormulas = new[] {0, 2, 4, 6, 9, 10}}
            };
        }

        protected void InitMaterials()
        {
            Materials = new List<BaseItem>()
            {
                new BaseItem(){Id=0,Name = "Сталь чорна"},
                new BaseItem(){Id=1,Name = "Сталь оцинкована"},
                new BaseItem(){Id=2,Name = "Мідь"}
            };
        }

        protected void InitProfileSections()
        {
            ProfileSections = new List<ProfileSection>()
            {
                new ProfileSection() {Id = 0, MaterialId = 0, Name = "Круглий для вертикальних заземлювачів", Diameter = 16,Thickness = -1,Square = -1},
                new ProfileSection() {Id = 1, MaterialId = 0, Name = "Круглий для горизонтальних заземлювачів",Diameter = 10,Thickness = -1,Square = -1},
                new ProfileSection() {Id = 2, MaterialId = 0, Name = "Прямокутний",Diameter = -1,Thickness = 4,Square = 100},
                new ProfileSection() {Id = 3, MaterialId = 0, Name = "Кутовий",Diameter = -1,Thickness = 4,Square = 100},
                new ProfileSection() {Id = 4, MaterialId = 0, Name = "Трубний",Diameter = 32,Thickness = 3.5,Square = -1},

                new ProfileSection() {Id = 5, MaterialId = 1, Name = "Круглий для вертикальних заземлювачів",Diameter = 12,Thickness = -1,Square = -1},
                new ProfileSection() {Id = 6, MaterialId = 1, Name = "Круглий для горизонтальних заземлювачів",Diameter = 10,Thickness = -1,Square = -1},
                new ProfileSection() {Id = 7, MaterialId = 1, Name = "Прямокутний",Diameter = -1,Thickness = 3,Square = 75},
                new ProfileSection() {Id = 8, MaterialId = 1, Name = "Трубний",Diameter = 25,Thickness = 2,Square = -1},

                new ProfileSection() {Id = 9, MaterialId = 2, Name = "Круглий",Diameter = 12,Thickness = -1,Square = -1},
                new ProfileSection() {Id = 10, MaterialId = 2, Name = "Прямокутний",Diameter = -1,Thickness = 2,Square = 50},
                new ProfileSection() {Id = 11, MaterialId = 2, Name = "Трубний",Diameter = 20,Thickness = 2,Square = -1},
                new ProfileSection() {Id = 12, MaterialId = 2, Name = "Канат багатопровідний",Diameter = 1.8,Thickness = -1,Square = 35},
            };
        }

        protected void InitSoils()
        {
            Soils = new List<BaseItem>()
            {
                new BaseItem(){Id = 0, Name = "Глина "},
                new BaseItem(){Id = 1, Name = "Суглинок "},
                new BaseItem(){Id = 2, Name = "Чорнозем "},
                new BaseItem(){Id = 3, Name = "Торф"},
                new BaseItem(){Id = 4, Name = "Садова земля "},
                new BaseItem(){Id = 5, Name = "Супісок "},
                new BaseItem(){Id = 6, Name = "Пісок "},
                //new BaseItem(){Id = 7, Name = "Кам'янистий "},
                //new BaseItem(){Id = 8, Name = "Скелястий "},
                new BaseItem(){Id = 9, Name = "Вода морська"},
                new BaseItem(){Id = 10, Name = "Вода річкова"},
                new BaseItem(){Id = 11, Name = "Вода водоймищ"},
                new BaseItem(){Id = 12, Name = "Вода струмкова"},
                new BaseItem(){Id = 13, Name = "Вода ґрунтова"},
            };
        }

        protected void InitResistivitySoils()
        {
            ResistivitySoils = new[]
            {
                new ResistivitySoil() {Id = 0, RecomendedValue = 40, SoilIds = new []{0,4}},
                new ResistivitySoil() {Id = 1, RecomendedValue = 100, SoilIds = new []{1}},
                new ResistivitySoil() {Id = 2, RecomendedValue = 20, SoilIds = new []{2,3}},
                new ResistivitySoil() {Id = 3, RecomendedValue = 300, SoilIds = new []{5}},
                new ResistivitySoil() {Id = 4, RecomendedValue = 700, SoilIds = new []{6}},
                new ResistivitySoil() {Id = 5, RecomendedValue = 1, SoilIds = new []{9}},
                new ResistivitySoil() {Id = 6, RecomendedValue = 80, SoilIds = new []{10}},
                new ResistivitySoil() {Id = 7, RecomendedValue = 50, SoilIds = new []{11,13}},
                new ResistivitySoil() {Id = 8, RecomendedValue = 60, SoilIds = new []{12}}
            };
        }

        protected void InitTypeElectrode()
        {
            TypeElectrode = new[]
            {
                new BaseItem() {Id = 0, Name = "Вертикальний"},
                new BaseItem() {Id = 1, Name = "Горизонтальний"}
            };
        }

        protected void InitVerticalLengthElectrode()
        {
            VerticalLengthElectrode = new[]
            {
                new BaseItem() {Id = 0, Name = "3"},
                new BaseItem() {Id = 1, Name = "5"}
            };
        }

        private void InitHorizontalLengthElectrode()
        {
            HorizontalLengthElectrode = new[]
            {
                new BaseItem() {Id = 2, Name = "10"},
                new BaseItem() {Id = 3, Name = "50"}
            };
        }

        protected void InitHeaven()
        {
            Heaven = new[]
            {
                new BaseItem() {Id = 0, Name = "I"},
                new BaseItem() {Id = 1, Name = "II"},
                new BaseItem() {Id = 2, Name = "III"},
                new BaseItem() {Id = 3, Name = "IV"}
            };
        }

        protected void InitHumidity()
        {
            Humidity = new[]
            {
                new BaseItem(){Id = 0,Name="Підвищена"}, 
                new BaseItem(){Id = 1,Name="Нормальна"}, 
                new BaseItem(){Id = 2,Name="Мала"} 
            };
        }
        
        private void InitGroundItems()
        {
            GroundItems = new List<GroundItem>
            {
                new GroundItem()
                {
                    Id = 0,
                    Name = "Стержневий круглого перерізу \n(трубчастий) або кутовий біля\nповерхні землі",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/0.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula0.png'></img>")
                },
                new GroundItem()
                {
                    Id = 1,
                    Name = "Стержневий круглого перерізу \n(трубчастий) або кутовий в землі",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/1.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula1.png'></img>")
                },
                new GroundItem()
                {
                    Id = 2,
                    Name = "Заземлювач розміщений на поверхні \nземлі (стержень, труба,\nполоса, кабель і т.д.)",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/2.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula2.png'></img>")
                },
                new GroundItem()
                {
                    Id = 3,
                    Name = "Заземлювач розміщений в землі \n(стержень, труба, полоса,\n кабель і т.д.)",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/3.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula3.png'></img>")
                },
                new GroundItem()
                {
                    Id = 4,
                    Name = "Прямокутна пластина на\nповерхні землі",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/4.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula4.png'></img>")
                },

                new GroundItem()
                {
                    Id = 5,
                    Name = "Пластинчастий в землі (пластина поставлена на ребро)",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/5.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula5.png'></img>")
                },
                new GroundItem()
                {
                    Id = 6,
                    Name = "Кругла пластина на поверхні землі",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/6.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula6.png'></img>")
                },
                new GroundItem()
                {
                    Id = 7,
                    Name = "Кругла пластина в землі",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/7.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula7.png'></img>")
                },
                new GroundItem()
                {
                    Id = 8,
                    Name = "Кульовий в землі",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/8.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula8.png'></img>")
                },
                new GroundItem()
                {
                    Id = 9,
                    Name = "Напівкульовий біля поверхні землі",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/9.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula9.png'></img>")
                },
                new GroundItem()
                {
                    Id = 10,
                    Name = "Кільцевий на поверхні землі",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/10.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula10.png'></img>")
                },
                new GroundItem()
                {
                    Id = 11,
                    Name = "Кільцевий в землі",
                    SchemeSource = string.Format("<img src='../../Content/Images/Grounding/11.png'></img>"),
                    FormulaSource = string.Format("<img src='../../Content/Images/Grounding/Formula11.png'></img>")
                }
            };
        }
    }
}
