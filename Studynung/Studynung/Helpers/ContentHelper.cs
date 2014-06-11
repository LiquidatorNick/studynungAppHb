using System.Text;

namespace Studynung.Helpers
{
    public static class ContentHelper
    {
        public static string HaracteristicTable
        {
            get
            {
                var builder = new StringBuilder();
                builder.Append("<table id='tableHaracteristic' class='sn-table' style='display: none'>");
                builder.Append("<thead>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td'>Характеристика установок</td>");
                builder.Append("       <td class='sn-table-td'>Найбільший допустимий опір заземлювального пристрою, Ом </td>");
                builder.Append("   </tr>");
                builder.Append("</thead>");
                builder.Append("<tbody>");
                builder.Append("   <tr>");
                builder.Append("       <td colspan='2' class='sn-table-td'>Електроустановки напругою більше 1000 В</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td'>1. Захисне заземлення в установках з великими струмами замикання на землю (500 А та більше)</td>");
                builder.Append("       <td class='sn-table-td'>0.5</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td'>2. Захисне заземлення в установках з малими струмами  замикання на землю (до 500 А):</td> ");
                builder.Append("       <td class='sn-table-td'></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td'>–	без компенсації ємнісних струмів при:</td> ");
                builder.Append("       <td class='sn-table-td'></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>а) одночасному використанні заземлювального пристрою і для електроустановок до 1000 В;</td>");
                builder.Append("       <td>125 / Із, але не більше 10 (Із –  розрахунковий опір замикання на землю, А)</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right sn-table-td-only-bottom'>б) використанні заземлювального пристрою лише для установок понад 1000 В;</td>");
                builder.Append("       <td class='sn-table-td-only-bottom'>250 / Із, але не більше 10 (Із –  розрахунковий опір замикання на землю, А)</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td'>–	з компенсацією ємнісних струмів;</td>");
                builder.Append("       <td class='sn-table-td'></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class=sn-table-td-only-right'>а) до заземлювального пристрою не приєднані апарати, котрі компенсують ємнісний струм</td>");
                builder.Append("       <td class='sn-table-td-only-right'>125 / Із, але не більше 10 (Із –залишковий струм замикання на землю, котрий виникає при відключенні найбільш потужного з компенсуючих апаратів, але не менше 30 А)</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right sn-table-td-only-bottom'>б) апарати, котрі компенсують ємнісний струм</td>");
                builder.Append("       <td class='sn-table-td-only-right sn-table-td-only-bottom'>125 / Із, але не більше 10 (Із  приймають рівним 1,25 номінального струму компенсуючих апаратів)</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td colspan='2' class='sn-table-td'>Електроустановки напругою менше 1000 В</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td-only-right'>3 Установки з глухим заземленням нейтралі при лінійних напругах, В:</td>");
                builder.Append("       <td></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td-only-right'>а) джерел трифазного (однофазного) струму:</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>660 (380)</td>");
                builder.Append("       <td>2</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>380 (220)</td>");
                builder.Append("       <td>4</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>220 (127)</td>");
                builder.Append("       <td>8</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td-only-right'>б) повторне заземлення нульового робочого проводу повітряної лінії електропередачі (ПЛ):</td>");
                builder.Append("       <td></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>660</td>");
                builder.Append("       <td>15</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>380</td>");
                builder.Append("       <td>30</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>220</td>");
                builder.Append("       <td>60</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td-only-right'>в) всі повторні заземлення нульового робочого проводу ПЛ (сумарний опір)</td>");
                builder.Append("       <td></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>660</td>");
                builder.Append("       <td>15</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>380</td>");
                builder.Append("       <td>30</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right sn-table-td-only-bottom'>220</td>");
                builder.Append("       <td class='sn-table-td-only-bottom'>60</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td-only-right'>4.	Установки з ізольованою нейтраллю:</td>");
                builder.Append("       <td></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>а) захисне заземлення при потужності генераторів та трансформаторів 100 кВА і менше; та всі електроустановки постійного струму</td>");
                builder.Append("       <td>10</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>б) те ж в інших випадках </td>");
                builder.Append("       <td>4</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>в) заземлення гаків та штирів фазових проводів, встановлених на залізобетонних опорах, а також арматури цих опор</td>");
                builder.Append("       <td>50</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>г) заземлення металевих відтяжок опор в мережах з  ізольованою нейтраллю, закріплених нижнім кінцем на висоті менше, ніж 2,5 м від землі</td>");
                builder.Append("       <td>10</td>");
                builder.Append("   </tr>");
                builder.Append("</tbody>");
                builder.Append("</table>");
                return builder.ToString();
            }
        }
    }
}