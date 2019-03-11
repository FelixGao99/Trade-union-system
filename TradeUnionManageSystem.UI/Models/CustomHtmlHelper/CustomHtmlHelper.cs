using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TradeUnionManageSystem.BLL.Models;
using TradeUnionManageSystem.UI.Extensions.DataProvider;

namespace System.Web.Mvc
{
    /// <summary>
    /// 开窗类型枚举
    /// </summary>
    public enum DataBrowserType
    {
        Honor = 1,
        ModelWorker = 2,
        Proposal = 3,
        WorkersCongress = 4,
        WorkingTeam = 5,
        Employee = 6,
        Position = 7,
        WorkingUnit = 8,
        WorkingGroup = 9
    }


    /// <summary>
    /// 开窗辅助类
    /// </summary>
    public static class DataBrowserManager
    {
        /// <summary>
        /// 获取开窗表格数据源
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static StringBuilder GetTBodyString(DataBrowserType type)
        {
            var tbody = new StringBuilder();

            switch (type)
            {
                case DataBrowserType.Employee:
                    var employees = EmployeeDataProvider.GetAll();
                    foreach (var item in employees)
                    {
                        tbody.Append("<tr><td><input class='databrowser-selector' type='radio' name='selector'/></td>");
                        foreach (PropertyInfo pInfo in item.GetType().GetProperties())
                        {
                            var value = pInfo.GetValue(item);
                            if (value != null)
                                tbody.AppendFormat("<td data-property='{0}'>{1}</td>", pInfo.Name, value.ToString());
                        }
                        tbody.Append("</tr>");
                    };
                    break;
                case DataBrowserType.Position:
                    var positions = PositionDataProvider.GetAll();
                    foreach (var item in positions)
                    {
                        tbody.Append("<tr><td><input class='databrowser-selector' type='radio' name='selector'/></td>");
                        foreach (PropertyInfo pInfo in item.GetType().GetProperties())
                        {
                            var value = pInfo.GetValue(item);
                            if (value != null)
                                tbody.AppendFormat("<td data-property='{0}'>{1}</td>", pInfo.Name, value.ToString());
                        }
                        tbody.Append("</tr>");
                    };
                    break;
                case DataBrowserType.WorkingUnit:
                    var workingUnits = WorkingUnitDataProvider.GetAll();
                    foreach (var item in workingUnits)
                    {
                        tbody.Append("<tr><td><input class='databrowser-selector' type='radio' name='selector'/></td>");
                        foreach (PropertyInfo pInfo in item.GetType().GetProperties())
                        {
                            var value = pInfo.GetValue(item);
                            if (value != null)
                                tbody.AppendFormat("<td data-property='{0}'>{1}</td>", pInfo.Name, value.ToString());
                        }
                        tbody.Append("</tr>");
                    };
                    break;
                case DataBrowserType.WorkingGroup:
                    var workingGroups = WorkingGroupDataProvider.GetAll();
                    foreach (var item in workingGroups)
                    {
                        tbody.Append("<tr><td><input class='databrowser-selector' type='radio' name='selector'/></td>");
                        foreach (PropertyInfo pInfo in item.GetType().GetProperties())
                        {
                            var value = pInfo.GetValue(item);
                            if (value != null)
                                tbody.AppendFormat("<td data-property='{0}'>{1}</td>", pInfo.Name, value.ToString());
                        }
                        tbody.Append("</tr>");
                    };
                    break;
            }

            return tbody;
        }
    }


    /// <summary>
    /// 自定义Html帮助类
    /// </summary>
    public static class CustomHtmlHelper
    {
        /// <summary>
        /// 开窗按钮
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="data_window_id">开窗元素ID</param>
        /// <returns></returns>
        public static MvcHtmlString DataBrowserBtn(this HtmlHelper helper, DataBrowserType type, string targetPropertyName)
        {
            string data_window_id = "DataBrowser-" + Enum.GetName(typeof(DataBrowserType), type);

            string html_str = "<button class=\"btn btn-default btn-databrowser-open col-md-1\" data-property=\"{0}\" data-toggle=\"modal\" data-target=\"#{1}\">" +
                                "<span class=\"glyphicon glyphicon-search\"></span>" +
                              "</button>";

            return MvcHtmlString.Create(String.Format(html_str, targetPropertyName, data_window_id));
        }

        /// <summary>
        /// 开窗表格
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MvcHtmlString DataBrowserWindow(this HtmlHelper helper, DataBrowserType type)
        {
            // 开窗元素ID
            string dataBrowser_id = "";

            // 根据枚举确定开窗类型
            Object obj = null;
            switch (type)
            {
                case DataBrowserType.Honor:
                    obj = new Honor();
                    dataBrowser_id = "DataBrowser-Honor";
                    break;
                case DataBrowserType.ModelWorker:
                    obj = new ModelWorker();
                    dataBrowser_id = "DataBrowser-ModelWorker";
                    break;
                case DataBrowserType.Proposal:
                    obj = new Proposal();
                    dataBrowser_id = "DataBrowser-Proposal";
                    break;
                case DataBrowserType.WorkersCongress:
                    obj = new WorkersCongress();
                    dataBrowser_id = "DataBrowser-WorkersCongress";
                    break;
                case DataBrowserType.WorkingTeam:
                    obj = new WorkingTeam();
                    dataBrowser_id = "DataBrowser-WorkingTeam";
                    break;
                case DataBrowserType.Employee:
                    obj = new Employee();
                    dataBrowser_id = "DataBrowser-Employee";
                    break;
                case DataBrowserType.Position:
                    obj = new Position();
                    dataBrowser_id = "DataBrowser-Position";
                    break;
                case DataBrowserType.WorkingUnit:
                    obj = new WorkingUnit();
                    dataBrowser_id = "DataBrowser-WorkingUnit";
                    break;
                case DataBrowserType.WorkingGroup:
                    obj = new WorkingGroup();
                    dataBrowser_id = "DataBrowser-WorkingGroup";
                    break;
            }

            // 生成表头信息
            var thead = new StringBuilder();
            thead.Append("<th></th>");

            Type t = obj.GetType();
            foreach(PropertyInfo pInfo in t.GetProperties())
            {
                thead.AppendFormat("<th>{0}</th>", pInfo.Name);
            }

            // 生成表中行信息
            var tbody = DataBrowserManager.GetTBodyString(type);

            // 生成开窗整体结构
            var result = new StringBuilder();
            result.AppendFormat(
                @"<div class='modal fade' id='{0}' tabindex='-1' role='dialog' aria-labelledby='myModalLabel-{0}' aria-hidden='true'>" +
                    "<div class='modal-dialog databrowser-dialog'>" +
                        "<div class='modal-content'>" + 
                            "<div class='modal-header'>" + 
                                "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button>" +
                                "<h4 class='modal-title' id='myModalLabel-{0}'>开窗测试</h4>" +
                            "</div>" +
                            "<div class='modal-body'>" +
                                "<table class='table table-striped'>" +
                                    "<thead>" +
                                        "<tr>" +
                                            "{1}" +
                                        "</tr>" +
                                    "</thead>" +
                                    "<tbody>" +
                                        "{2}" +
                                    "</tbody>" +
                                "</table>" +
                            "</div>" +
                            "<div class='modal-footer'>" +
                                "<button type='button' class='btn btn-primary databrowser-ok'>选择</button>" +
                                "<button type='button' class='btn btn-default' data-dismiss='modal'>关闭</button>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                 "</div>", dataBrowser_id, thead, tbody
            );

            return MvcHtmlString.Create(result.ToString());
        }
    }

}