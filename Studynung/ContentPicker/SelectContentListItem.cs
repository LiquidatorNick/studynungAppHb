using System.Collections.Generic;

namespace Studynung.ContentPicker
{
    public class SelectContentListItem 
    {
        public int Id { get; set; }
        public string FirstColumnValue { get; set; }
        public string SecondColumnValue { get; set; }
        public bool IsVisibleSecond { get; set; }

        public List<ContentItem> ContentItems { get; set; }
    }

    public class ContentItem
    {
        public ContentItem()
        {
            IsVisible = true;
        }

        public ContentItem(string value)
        {
            Value = value;
            IsVisible = true;
        }

        public ContentItem(string value, bool isVisible)
        {
            Value = value;
            IsVisible = isVisible;
        }

        public string Value { get; set; }

        public bool IsVisible { get; set; }
    }
}