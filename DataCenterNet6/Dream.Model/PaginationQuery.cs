using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dream.Model
{
    /// <summary>
    /// 翻页查询条件实体类
    /// </summary>
    public class PaginationQuery
    {
        public string TableName { get; set; }
        public string Fields { get; set; }
        public string Orderby { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SqlWhere { get; set; }
        public bool NeedTotalCount { get; set; }
        public int TotalCount { get; set; }
        public DynamicParameters GenerateParameters()
        {
            var p = new DynamicParameters();
            p.Add("@tblName", TableName);
            p.Add("@strGetFields", Fields);
            p.Add("@strOrder", Orderby);
            p.Add("@strWhere", SqlWhere);
            p.Add("@pageIndex", PageIndex);
            p.Add("@pageSize", PageSize);
            if (NeedTotalCount) p.Add("@doCount", 1);
            else p.Add("@doCount", 0);
            p.Add("@recordCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return p;
        }
    }
}
