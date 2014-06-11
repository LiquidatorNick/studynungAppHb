using System;
using System.Collections.Generic;
using System.Linq;
using Studynung.ContentPicker;
using Studynung.ProtectiveEarthing.Items;
using Studynung.ProtectiveEarthing.Logic.Items;

namespace Studynung.Helpers
{
    public static class ConvertHelper
    {
        public static IEnumerable<SelectContentListItem> ConvertBaseItem(BaseItem[] items)
        {
            return items.Select(baseItem => new SelectContentListItem()
            {
                Id = baseItem.Id,
                ContentItems = new List<ContentItem>()
                {
                    new ContentItem(baseItem.Name)
                }
            });
        }
        public static IEnumerable<SelectContentListItem> ConvertBaseItemWithImage(BaseItemWithImage[] items)
        {
            return items.Select(baseItem => new SelectContentListItem()
            {
                Id = baseItem.Id,
                ContentItems = new List<ContentItem>()
                {
                    new ContentItem(baseItem.Name),
                    new ContentItem(baseItem.ImgSource)
                }
            });
        }
        public static IEnumerable<SelectContentListItem> ConvertProfileSection(List<ProfileSection> items)
        {
            return items.Select(baseItem => new SelectContentListItem()
            {
                Id = baseItem.Id,
                ContentItems = new List<ContentItem>()
                {
                    new ContentItem(baseItem.Name),
                    new ContentItem(Convert.ToString(baseItem.MaterialId), false),
                    new ContentItem(baseItem.Diameter.ToString(), false),
                    new ContentItem(baseItem.Thickness.ToString(), false),
                    new ContentItem(baseItem.Square.ToString(), false),
                    new ContentItem(baseItem.StringDiameter, false),
                    new ContentItem(baseItem.StringThickness, false),
                    new ContentItem(baseItem.StringSquare, false)
                }
            });
        }
        public static IEnumerable<SelectContentListItem> ConvertResistivitySoil(IEnumerable<ResistivitySoil> items)
        {
            return items.Select(baseItem => new SelectContentListItem()
            {
                Id = baseItem.Id,
                ContentItems = new List<ContentItem>()
                {
                    new ContentItem(Convert.ToString(baseItem.RecomendedValue)),
                    new ContentItem(Convert.ToString(baseItem.StringSoilIds), false)
                }
            });
        }
        public static IEnumerable<SelectContentListItem> ConvertGroundItemWithScheme(this IEnumerable<GroundItem> items)
        {
            return items.Select(baseItem => new SelectContentListItem()
            {
                Id = baseItem.Id,
                ContentItems = new List<ContentItem>()
                {
                    new ContentItem(Convert.ToString(baseItem.Name)),
                    new ContentItem(Convert.ToString(baseItem.SchemeSource))
                }
            });
        }

        public static IEnumerable<SelectContentListItem> ConvertGroundItemWithFormula(this IEnumerable<GroundItem> items)
        {
            return items.Select(baseItem => new SelectContentListItem()
            {
                Id = baseItem.Id,
                ContentItems = new List<ContentItem>()
                {
                    new ContentItem(Convert.ToString(baseItem.FormulaSource))
                }
            });
        }
    }
}