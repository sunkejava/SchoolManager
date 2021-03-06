import config from "@/config/index";
import { contentType } from "@/config/enum";
const reqPath = config.headerApi + "/teacherinfo/";

// 列表
const search = {
  url: reqPath + "search",
  method: "post",
  dataType: "array"
};
// 添加
const add = {
  url: reqPath + "Add",
  method: "post"
};
// 删除
const deleted = {
  url: reqPath + "Delete/{ID}",
  method: "get"
};
// 批量删除
const batchDelete = {
  url: reqPath + "BatchDelete",
  method: "post"
};
// 修改
const edit = {
  url: reqPath + "Edit",
  method: "put"
};
// 详情
const detail = {
  url: reqPath + "{ID}",
  method: "get"
};
const exportExcel = {
  url: reqPath + "ExportExcel",
  method: "post",
  contentType: contentType.stream
};
const exportExcelByIds = {
  url: reqPath + "ExportExcelByIds",
  method: "post",
  contentType: contentType.stream
};
const getExcelTemplate = {
  url: reqPath + "GetExcelTemplate",
  method: "get",
  contentType: contentType.stream
};
// 导入
const imported = {
  url: reqPath + "Import",
  method: "post"
};

const getPositionInfo = {
  url: reqPath + "getPositionInfos",
  method: "get",
  dataType: "array"
}; 
const getTitleInfo = {
  url: reqPath + "getTitleInfos",
  method: "get",
  dataType: "array"
}; 
const getSchoolInfo = {
  url: reqPath + "getSchoolInfos",
  method: "get",
  dataType: "array"
}; 
const getMajorInfo = {
  url: reqPath + "getMajorInfos",
  method: "get",
  dataType: "array"
}; 
const getGradeClassInfo = {
  url: reqPath + "getGradeClassInfos",
  method: "get",
  dataType: "array"
}; 
const getProjectInfo = {
  url: reqPath + "getProjectInfos",
  method: "get",
  dataType: "array"
}; 
const getHonorInfo = {
  url: reqPath + "getHonorInfos",
  method: "get",
  dataType: "array"
}; 
const getSubjectInfo = {
  url: reqPath + "getSubjectInfos",
  method: "get",
  dataType: "array"
}; 

export default {
getPositionInfo,
getTitleInfo,
getSchoolInfo,
getMajorInfo,
getGradeClassInfo,
getProjectInfo,
getHonorInfo,
getSubjectInfo,

  search,
  add,
  deleted,
  batchDelete,
  edit,
  detail,
  exportExcel,
  exportExcelByIds,
  getExcelTemplate,
  imported
};
