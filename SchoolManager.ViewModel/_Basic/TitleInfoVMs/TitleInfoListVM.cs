using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.TitleInfoVMs
{
    public partial class TitleInfoListVM : BasePagedListVM<TitleInfo_View, TitleInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<TitleInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<TitleInfo_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<TitleInfo_View> GetSearchQuery()
        {
            var query = DC.Set<TitleInfo>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new TitleInfo_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class TitleInfo_View : TitleInfo{

    }
}
