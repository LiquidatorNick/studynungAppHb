using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Studynung.ContentPicker
{
    public static class ContentPickerStatic
    {
        private const string TextBoxStyle = "width: 300px; height: 110%";
        private const string ButtonStyle = "position: relative; left: -10px; height: 100%;";
        private const string ContentDivStyle = "position: absolute; background: white; z-index: 1;";
        private const string ContentTbodyStyle = "display: block; max-height :400px; overflow-y: auto; overflow-x: hidden;";

        private static int _itemIndex = 0;

        public static MvcHtmlString ContentPicker(this HtmlHelper htmlHelper, string name, IEnumerable<SelectContentListItem> contentListItems,
            string onSelectedFunc = null, string onClickFunc = null)
        {
            _itemIndex++;
            string textboxId = string.Format("{0}_contentPicker_textbox", name);
            string buttonId = string.Format("{0}_btnselect", name);
            string contentId = string.Format("{0}_selectItems", name);
            string hiddenId = string.Format("{0}_contentPicker_hidden", name);
            var contentRowBuilder = new TagBuilder("tr")
            {
                InnerHtml = string.Format("<td> {0} </td>", CreateContent(contentListItems, contentId))
            };
            var tableBuilder = new TagBuilder("table")
            {
                InnerHtml = string.Format("<tbody>{0}{1}</tbody>", MainPart(textboxId, buttonId, hiddenId), contentRowBuilder)
            };
            tableBuilder.AddCssClass("tableContentPicker");
            var div = new TagBuilder("div")
            {
                InnerHtml = string.Format("{0}{1}", tableBuilder, AppendScript(textboxId, buttonId, contentId, hiddenId, onSelectedFunc, onClickFunc)),
            };
            div.Attributes.Add("id", name);
            return new MvcHtmlString(div.ToString());
        }

        private static string MainPart(string textboxId, string buttonId, string hiddenId)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<tr>");
            stringBuilder.Append("<td>");
            stringBuilder.Append("<div>");
            stringBuilder.Append(string.Format("<input type='text' style='{1}' id='{0}'/>", textboxId, TextBoxStyle));
            stringBuilder.Append(string.Format("<input type='button' value='{0}' id='{1}' style='{2}'/>", "&darr;", buttonId, ButtonStyle));
            stringBuilder.Append(string.Format("<input type='hidden' id='{0}'/>", hiddenId));
            stringBuilder.Append("</div>");
            stringBuilder.Append("</td>");
            stringBuilder.Append("</tr>");
            return stringBuilder.ToString();
        }

        private static string CreateContent(IEnumerable<SelectContentListItem> contentListItems, string contentId)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("<div style='{0}'>", ContentDivStyle);
            stringBuilder.AppendFormat("<table id='{0}' style='display: none'>", contentId);
            stringBuilder.AppendFormat("<tbody style='{0}'>", ContentTbodyStyle);
            foreach (var selectContentListItem in contentListItems)
            {
                stringBuilder.Append("<tr>");
                stringBuilder.AppendFormat("<td class='{1}'>{0}</td>", selectContentListItem.FirstColumnValue,
                    string.Format("{0}_1", contentId));
                if (!string.IsNullOrEmpty(selectContentListItem.SecondColumnValue))
                    stringBuilder.AppendFormat("<td {1} class='{2}'>{0}</td> ", selectContentListItem.SecondColumnValue,
                        selectContentListItem.IsVisibleSecond
                        ? ""
                        : "style='display:none;'",
                    string.Format("{0}_2", contentId));
                stringBuilder.AppendFormat("<td style='width: 0px;' class='{0}'><input type='hidden' value='" + selectContentListItem.Id + "'/></td> ",
                    string.Format("{0}_hidden", contentId));
                stringBuilder.Append("</tr>");
            }
            stringBuilder.AppendFormat("</tbody>");
            stringBuilder.AppendFormat("</table>");
            stringBuilder.Append("</div>");
            return stringBuilder.ToString();
        }

        private static string AppendScript(string textboxId, string buttonId, string contentId, string hiddenId, string onSelectedFunc, string onClickFunc)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<script>");
            stringBuilder.Append("$('#" + contentId + " tr').click(function () {");
            stringBuilder.Append("var value = $(this).find('td:first').html();");
            stringBuilder.Append("var curId = $(this).find('td input[type=hidden]').val();");
            stringBuilder.Append(string.Format("$('#{0}').val(value);", textboxId));
            stringBuilder.Append(string.Format("$('#{0}').val(curId);", hiddenId));
            stringBuilder.Append("$('#" + contentId + " tr').css({ 'background': 'transparent', 'color': 'black' });");
            stringBuilder.Append("$(this).css({ 'background': '#3399FF', 'color': 'white' });");
            stringBuilder.AppendFormat("$('#{0}').fadeToggle();", contentId);
            if (!string.IsNullOrEmpty(onSelectedFunc))
                stringBuilder.AppendFormat("{0}(curId);", onSelectedFunc);
            stringBuilder.Append("});");
            stringBuilder.Append(string.Format("$('#{0}').click(function () {{", buttonId));
            stringBuilder.AppendFormat(
                string.IsNullOrEmpty(onClickFunc)
                ? string.Format("$('#{0}').fadeToggle();", contentId)
                : string.Format("{0}($('#{1}'));", onClickFunc, contentId));
            stringBuilder.Append("});");
            stringBuilder.Append("</script>");
            return stringBuilder.ToString();
        }
    }
}

