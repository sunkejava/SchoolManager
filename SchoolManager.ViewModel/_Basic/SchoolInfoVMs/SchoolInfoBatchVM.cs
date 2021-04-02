using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.SchoolInfoVMs
{
    public partial class SchoolInfoBatchVM : BaseBatchVM<SchoolInfo, SchoolInfo_BatchEdit>
    {
        public SchoolInfoBatchVM()
        {
            ListVM = new SchoolInfoListVM();
            LinkedVM = new SchoolInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class SchoolInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
