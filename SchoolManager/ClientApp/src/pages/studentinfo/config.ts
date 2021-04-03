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
        label: "入学时间"
    },
    {
        key: "Name_view",
        label: "学生荣誉"
    },
    {
        key: "Name_view2",
        label: "学生科目"
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
        key: "Name_view3",
        label: "毕业院校"
    },
    {
        key: "Name_view4",
        label: "专业"
    },
    {
        key: "PhotoId",
        label: "照片",
        isSlot: true 
    },
    {
        key: "Name_view5",
        label: "班级"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];


