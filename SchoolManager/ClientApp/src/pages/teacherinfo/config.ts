import i18n from "@/lang";

export const ASSEMBLIES: Array<string> = [
  "add",
  "edit",
  "delete",
  "export",
  "imported"
];

export const TABLE_HEADER: Array<object> = [


    {
        key: "InTake",
        label: "任教日期"
    },
    {
        key: "Name_view",
        label: "职位信息"
    },
    {
        key: "Name_view2",
        label: "职称信息"
    },
    {
        key: "Name_view3",
        label: "教师培训"
    },
    {
        key: "Name_view4",
        label: "教师荣誉"
    },
    {
        key: "Name_view5",
        label: "授业科目"
    },
    {
        key: "Code",
        label: "代码"
    },
    {
        key: "Name",
        label: "名称"
    },
    {
        key: "CellPhone",
        label: "联系电话"
    },
    {
        key: "ZipCode",
        label: "邮编"
    },
    {
        key: "EmContacts",
        label: "紧急联系人"
    },
    {
        key: "EmConPhone",
        label: "联系人电话"
    },
    {
        key: "EnglishName_view",
        label: "毕业院校"
    },
    {
        key: "Name_view6",
        label: "专业"
    },
    {
        key: "PhotoId",
        label: "照片",
        isSlot: true 
    },
    {
        key: "Name_view7",
        label: "班级"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];


