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
        key: "Code",
        label: "代码"
    },
    {
        key: "Name",
        label: "名称"
    },
    {
        key: "EnglishName",
        label: "英文名称"
    },
    {
        key: "PinyinName",
        label: "全拼名称"
    },
    {
        key: "SimplePinyinName",
        label: "简拼名称"
    },
    {
        key: "SimpleName",
        label: "简称"
    },
    {
        key: "Contacts",
        label: "联系人"
    },
    {
        key: "Phone",
        label: "联系电话"
    },
    {
        key: "TypeOfEducation",
        label: "教育类型"
    },
    {
        key: "Address",
        label: "地址"
    },
    {
        key: "TypeOfUrbanAndRural",
        label: "驻地城乡类型"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const TypeOfEducationTypes: Array<any> = [
  { Text: "学前教育", Value: "XQJY" },
  { Text: "初等教育", Value: "CDJY" },
  { Text: "中等教育", Value: "ZDJY" },
  { Text: "高等教育", Value: "GDJY" },
  { Text: "特殊教育", Value: "TSJY" }
];
export const TypeOfUrbanAndRuralTypes: Array<any> = [
  { Text: "主城区", Value: "ZCQ" },
  { Text: "城乡结合区", Value: "CXJHQ" },
  { Text: "镇中心区", Value: "ZZXQ" },
  { Text: "镇乡结合区", Value: "ZXJHQ" },
  { Text: "特殊区域", Value: "TSQY" },
  { Text: "乡中心区", Value: "XZXQ" },
  { Text: "村庄", Value: "CZ" }
];

