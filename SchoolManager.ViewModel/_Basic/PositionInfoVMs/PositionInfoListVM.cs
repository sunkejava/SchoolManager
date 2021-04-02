using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.PositionInfoVMs
{
    public partial class PositionInfoListVM : BasePagedListVM<PositionInfo_View, PositionInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<PositionInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<PositionInfo_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PositionInfo_View> GetSearchQuery()
        {
            var query = DC.Set<PositionInfo>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new PositionInfo_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class PositionInfo_View : PositionInfo{

    }
}
