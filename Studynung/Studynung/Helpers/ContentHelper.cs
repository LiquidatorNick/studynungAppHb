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
                builder.Append("       <td class='sn-table-td'>�������������� ���������</td>");
                builder.Append("       <td class='sn-table-td'>��������� ���������� ��� ��������������� ��������, �� </td>");
                builder.Append("   </tr>");
                builder.Append("</thead>");
                builder.Append("<tbody>");
                builder.Append("   <tr>");
                builder.Append("       <td colspan='2' class='sn-table-td'>���������������� �������� ����� 1000 �</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td'>1. ������� ���������� � ���������� � �������� �������� ��������� �� ����� (500 � �� �����)</td>");
                builder.Append("       <td class='sn-table-td'>0.5</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td'>2. ������� ���������� � ���������� � ������ ��������  ��������� �� ����� (�� 500 �):</td> ");
                builder.Append("       <td class='sn-table-td'></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td'>�	��� ����������� ������� ������ ���:</td> ");
                builder.Append("       <td class='sn-table-td'></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>�) ����������� ����������� ��������������� �������� � ��� ���������������� �� 1000 �;</td>");
                builder.Append("       <td>125 / ��, ��� �� ����� 10 (�� �  ������������� ��� ��������� �� �����, �)</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right sn-table-td-only-bottom'>�) ����������� ��������������� �������� ���� ��� ��������� ����� 1000 �;</td>");
                builder.Append("       <td class='sn-table-td-only-bottom'>250 / ��, ��� �� ����� 10 (�� �  ������������� ��� ��������� �� �����, �)</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td'>�	� ������������ ������� ������;</td>");
                builder.Append("       <td class='sn-table-td'></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class=sn-table-td-only-right'>�) �� ��������������� �������� �� ������� �������, ���� ����������� ������� �����</td>");
                builder.Append("       <td class='sn-table-td-only-right'>125 / ��, ��� �� ����� 10 (�� ����������� ����� ��������� �� �����, ������ ������ ��� ��������� ������� ��������� � ������������ �������, ��� �� ����� 30 �)</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right sn-table-td-only-bottom'>�) �������, ���� ����������� ������� �����</td>");
                builder.Append("       <td class='sn-table-td-only-right sn-table-td-only-bottom'>125 / ��, ��� �� ����� 10 (��  ��������� ����� 1,25 ����������� ������ ������������ �������)</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td colspan='2' class='sn-table-td'>���������������� �������� ����� 1000 �</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td-only-right'>3 ��������� � ������ ����������� ������� ��� ������ ��������, �:</td>");
                builder.Append("       <td></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr>");
                builder.Append("       <td class='sn-table-td-only-right'>�) ������ ���������� (�����������) ������:</td>");
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
                builder.Append("       <td class='sn-table-td-only-right'>�) �������� ���������� ��������� �������� ������� �������� �� ��������������� (��):</td>");
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
                builder.Append("       <td class='sn-table-td-only-right'>�) �� ������� ���������� ��������� �������� ������� �� (�������� ���)</td>");
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
                builder.Append("       <td class='sn-table-td-only-right'>4.	��������� � ����������� ���������:</td>");
                builder.Append("       <td></td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>�) ������� ���������� ��� ��������� ���������� �� �������������� 100 ��� � �����; �� �� ���������������� ��������� ������</td>");
                builder.Append("       <td>10</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>�) �� � � ����� �������� </td>");
                builder.Append("       <td>4</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>�) ���������� ���� �� ����� ������� �������, ������������ �� ������������� ������, � ����� �������� ��� ����</td>");
                builder.Append("       <td>50</td>");
                builder.Append("   </tr>");
                builder.Append("   <tr class='tableHaracteristic-tr'>");
                builder.Append("       <td class='sn-table-td-only-right'>�) ���������� ��������� ������� ���� � ������� �  ����������� ���������, ���������� ����� ����� �� ����� �����, �� 2,5 � �� ����</td>");
                builder.Append("       <td>10</td>");
                builder.Append("   </tr>");
                builder.Append("</tbody>");
                builder.Append("</table>");
                return builder.ToString();
            }
        }
    }
}