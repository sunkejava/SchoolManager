using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.HonorInfoVMs
{
    public partial class HonorInfoListVM : BasePagedListVM<HonorInfo_View, HonorInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<HonorInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<HonorInfo_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.TypeOfHonor),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<HonorInfo_View> GetSearchQuery()
        {
            var query = DC.Set<HonorInfo>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.TypeOfHonor, x=>x.TypeOfHonor)
                .Select(x => new HonorInfo_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                    TypeOfHonor = x.TypeOfHonor,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class HonorInfo_View : HonorInfo{

    }
}
