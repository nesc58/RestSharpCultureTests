namespace RestSharpCultureTests
{
    public class Person
    {
        public string AaName { get; set; }
        public string BbName { get; set; }
        public string CcName { get; set; }
        public string DdName { get; set; }
        public string EeName { get; set; }
        public string FfName { get; set; }
        public string GgName { get; set; }
        public string HhName { get; set; }
        public string IiName { get; set; }
        public string JjName { get; set; }
        public string KkName { get; set; }
        public string LlName { get; set; }
        public string MmName { get; set; }
        public string NnName { get; set; }
        public string OoName { get; set; }
        public string PpName { get; set; }
        public string QqName { get; set; }
        public string RrName { get; set; }
        public string SsName { get; set; }
        public string TtName { get; set; }
        public string UuName { get; set; }
        public string VvName { get; set; }
        public string WwName { get; set; }
        public string XxName { get; set; }
        public string YyName { get; set; }
        public string ZzName { get; set; }

        public static Person CreateDefault()
        {
            return new Person
            {
                AaName = nameof(AaName),
                BbName = nameof(BbName),
                CcName = nameof(CcName),
                DdName = nameof(DdName),
                EeName = nameof(EeName),
                FfName = nameof(FfName),
                GgName = nameof(GgName),
                HhName = nameof(HhName),
                IiName = nameof(IiName),
                JjName = nameof(JjName),
                KkName = nameof(KkName),
                LlName = nameof(LlName),
                MmName = nameof(MmName),
                NnName = nameof(NnName),
                OoName = nameof(OoName),
                PpName = nameof(PpName),
                QqName = nameof(QqName),
                RrName = nameof(RrName),
                SsName = nameof(SsName),
                TtName = nameof(TtName),
                UuName = nameof(UuName),
                VvName = nameof(VvName),
                WwName = nameof(WwName),
                XxName = nameof(XxName),
                YyName = nameof(YyName),
                ZzName = nameof(ZzName)
            };
        }

        public static string CreateDefaultJson()
        {
            return  @"{""aaName"":""AaName"",""bbName"":""BbName"",""ccName"":""CcName"",""ddName"":""DdName"",""eeName"":""EeName"",""ffName"":""FfName"",""ggName"":""GgName"",""hhName"":""HhName"",""iiName"":""IiName"",""jjName"":""JjName"",""kkName"":""KkName"",""llName"":""LlName"",""mmName"":""MmName"",""nnName"":""NnName"",""ooName"":""OoName"",""ppName"":""PpName"",""qqName"":""QqName"",""rrName"":""RrName"",""ssName"":""SsName"",""ttName"":""TtName"",""uuName"":""UuName"",""vvName"":""VvName"",""wwName"":""WwName"",""xxName"":""XxName"",""yyName"":""YyName"",""zzName"":""ZzName""}";
        }
    }
}