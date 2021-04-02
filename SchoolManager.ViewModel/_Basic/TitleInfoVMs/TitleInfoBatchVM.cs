using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.TitleInfoVMs
{
    public partial class TitleInfoBatchVM : BaseBatchVM<TitleInfo, TitleInfo_BatchEdit>
    {
        public TitleInfoBatchVM()
        {
            ListVM = new TitleInfoListVM();
            LinkedVM = new TitleInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class TitleInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
