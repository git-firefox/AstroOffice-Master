using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AstroOfficeWeb.Shared.VOs;
//using AstroShared.Models;

namespace ASDLL.DataAccess.Core
{
    public class BestBLL
    {
        public BestBLL()
        {
        }

        public bool isBestKundali(string best_Online_Result, short rating, short engine)
        {
            bool flag = false;
            if (engine == 1)
            {
                flag = this.isBestKundali_RedBook(best_Online_Result, rating);
            }
            if (engine == 2)
            {
                flag = this.isBestKundali_KP(best_Online_Result, rating);
            }
            return flag;
        }

        public bool isBestKundali_KP(string best_Online_Result, short rating)
        {
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            bool flag4;
            bool flag5;
            bool flag6;
            bool flag7;
            bool flag8;
            bool flag9;
            bool flag10;
            bool flag11;
            bool flag12;
            bool flag13;
            bool flag14;
            bool flag15;
            bool flag16 = false;
            bool flag17 = false;
            bool flag18 = false;
            bool flag19 = false;
            bool flag20 = false;
            bool flag21 = false;
            bool flag22 = false;
            bool flag23 = false;
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            kPHouseMappingVOs = new List<KPHouseMappingVO>();
            KPBLL kPBLL = new KPBLL();
            KundliVO kundliVO = new KundliVO()
            {
                Male = true
            };
            ProductSettingsVO productSettingsVO = new ProductSettingsVO();
            kPBLL.Process_Planet_Lagan(best_Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, 1, false);
            kPPlanetMappingVOs = kPBLL.Process_KPChart_GoodBad(kPPlanetMappingVOs, kundliVO, productSettingsVO);
            List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
            List<KPSigniVO> signi = new List<KPSigniVO>();
            short subLord = 0;
            short nakLord = 0;
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 7
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (rating != 3)
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 7
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        goto Label1;
                    }
                    flag = true;
                    goto Label0;
                }
                Label1:
                List<KPSigniVO> kPSigniVOs1 = signi;
                flag = ((
                    from Map in kPSigniVOs1
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() >= 1 ? false : (
                    from Map in signi
                    where Map.Signi == 7
                    select Map).Count<KPSigniVO>() < 1);
                Label0:
                if (!flag)
                {
                    flag17 = true;
                }
            }
            else
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 7
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        if ((
                            from Map in kPSigniVOs
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() < 1)
                        {
                            goto Label3;
                        }
                        if ((
                            from Map in signi
                            where Map.Signi == 2
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            if ((
                                from Map in signi
                                where Map.Signi == 7
                                select Map).Count<KPSigniVO>() < 1)
                            {
                                goto Label5;
                            }
                            flag15 = (
                                from Map in signi
                                where Map.Signi == 11
                                select Map).Count<KPSigniVO>() < 1;
                            goto Label2;
                        }
                        Label5:
                        flag15 = true;
                        goto Label2;
                    }
                }
                Label3:
                flag15 = true;
                Label2:
                if (!flag15)
                {
                    flag17 = true;
                }
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 5
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (rating != 3)
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 5
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        goto Label7;
                    }
                    flag1 = true;
                    goto Label6;
                }
                Label7:
                List<KPSigniVO> kPSigniVOs2 = signi;
                flag1 = ((
                    from Map in kPSigniVOs2
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() >= 1 ? false : (
                    from Map in signi
                    where Map.Signi == 5
                    select Map).Count<KPSigniVO>() < 1);
                Label6:
                if (!flag1)
                {
                    flag18 = true;
                }
            }
            else
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 5
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        if ((
                            from Map in kPSigniVOs
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() < 1)
                        {
                            goto Label9;
                        }
                        if ((
                            from Map in signi
                            where Map.Signi == 2
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            if ((
                                from Map in signi
                                where Map.Signi == 5
                                select Map).Count<KPSigniVO>() < 1)
                            {
                                goto Label11;
                            }
                            flag14 = (
                                from Map in signi
                                where Map.Signi == 11
                                select Map).Count<KPSigniVO>() < 1;
                            goto Label8;
                        }
                        Label11:
                        flag14 = true;
                        goto Label8;
                    }
                }
                Label9:
                flag14 = true;
                Label8:
                if (!flag14)
                {
                    flag18 = true;
                }
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 6
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (rating == 3)
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 1
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 5
                        select Map).Count<KPSigniVO>() < 1)
                    {
                        goto Label13;
                    }
                    flag13 = ((
                        from Map in signi
                        where Map.Signi == 1
                        select Map).Count<KPSigniVO>() < 1 ? true : (
                        from Map in signi
                        where Map.Signi == 5
                        select Map).Count<KPSigniVO>() < 1);
                    goto Label12;
                }
                Label13:
                flag13 = true;
                Label12:
                if (!flag13)
                {
                    flag19 = true;
                }
            }
            else if (((
                from Map in kPSigniVOs
                where Map.Signi == 5
                select Map).Count<KPSigniVO>() < 1 ? false : (
                from Map in signi
                where Map.Signi == 5
                select Map).Count<KPSigniVO>() >= 1))
            {
                flag19 = true;
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 2
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (rating != 3)
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 11
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        goto Label15;
                    }
                    flag2 = true;
                    goto Label14;
                }
                Label15:
                List<KPSigniVO> kPSigniVOs3 = signi;
                flag2 = ((
                    from Map in kPSigniVOs3
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() >= 1 ? false : (
                    from Map in signi
                    where Map.Signi == 11
                    select Map).Count<KPSigniVO>() < 1);
                Label14:
                if (!flag2)
                {
                    flag20 = true;
                }
            }
            else
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 11
                        select Map).Count<KPSigniVO>() < 1)
                    {
                        goto Label17;
                    }
                    flag12 = ((
                        from Map in signi
                        where Map.Signi == 2
                        select Map).Count<KPSigniVO>() < 1 ? true : (
                        from Map in signi
                        where Map.Signi == 11
                        select Map).Count<KPSigniVO>() < 1);
                    goto Label16;
                }
                Label17:
                flag12 = true;
                Label16:
                if (!flag12)
                {
                    flag20 = true;
                }
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 7
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (rating != 3)
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 7
                        select Map).Count<KPSigniVO>() < 1)
                    {
                        if ((
                            from Map in kPSigniVOs
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            goto Label19;
                        }
                        flag3 = true;
                        goto Label18;
                    }
                }
                Label19:
                List<KPSigniVO> kPSigniVOs4 = signi;
                if ((
                    from Map in kPSigniVOs4
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in signi
                        where Map.Signi == 7
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        goto Label21;
                    }
                    flag3 = (
                        from Map in signi
                        where Map.Signi == 11
                        select Map).Count<KPSigniVO>() < 1;
                    goto Label20;
                }
                Label21:
                flag3 = false;
                Label20:
                Label18:
                if (!flag3)
                {
                    flag22 = true;
                }
            }
            else
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 7
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        if ((
                            from Map in kPSigniVOs
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() < 1)
                        {
                            goto Label23;
                        }
                        if ((
                            from Map in signi
                            where Map.Signi == 2
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            if ((
                                from Map in signi
                                where Map.Signi == 7
                                select Map).Count<KPSigniVO>() < 1)
                            {
                                goto Label25;
                            }
                            flag11 = (
                                from Map in signi
                                where Map.Signi == 11
                                select Map).Count<KPSigniVO>() < 1;
                            goto Label22;
                        }
                        Label25:
                        flag11 = true;
                        goto Label22;
                    }
                }
                Label23:
                flag11 = true;
                Label22:
                if (!flag11)
                {
                    flag22 = true;
                }
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 6
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (rating != 3)
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 6
                        select Map).Count<KPSigniVO>() < 1)
                    {
                        if ((
                            from Map in kPSigniVOs
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            goto Label27;
                        }
                        flag4 = true;
                        goto Label26;
                    }
                }
                Label27:
                List<KPSigniVO> kPSigniVOs5 = signi;
                if ((
                    from Map in kPSigniVOs5
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in signi
                        where Map.Signi == 6
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        goto Label29;
                    }
                    flag4 = (
                        from Map in signi
                        where Map.Signi == 11
                        select Map).Count<KPSigniVO>() < 1;
                    goto Label28;
                }
                Label29:
                flag4 = false;
                Label28:
                Label26:
                if (!flag4)
                {
                    flag21 = true;
                }
            }
            else
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 6
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        if ((
                            from Map in kPSigniVOs
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() < 1)
                        {
                            goto Label31;
                        }
                        if ((
                            from Map in signi
                            where Map.Signi == 2
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            if ((
                                from Map in signi
                                where Map.Signi == 6
                                select Map).Count<KPSigniVO>() < 1)
                            {
                                goto Label33;
                            }
                            flag10 = (
                                from Map in signi
                                where Map.Signi == 11
                                select Map).Count<KPSigniVO>() < 1;
                            goto Label30;
                        }
                        Label33:
                        flag10 = true;
                        goto Label30;
                    }
                }
                Label31:
                flag10 = true;
                Label30:
                if (!flag10)
                {
                    flag21 = true;
                }
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 10
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (rating != 3)
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 10
                        select Map).Count<KPSigniVO>() < 1)
                    {
                        if ((
                            from Map in kPSigniVOs
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            goto Label35;
                        }
                        flag5 = true;
                        goto Label34;
                    }
                }
                Label35:
                List<KPSigniVO> kPSigniVOs6 = signi;
                if ((
                    from Map in kPSigniVOs6
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in signi
                        where Map.Signi == 10
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        goto Label37;
                    }
                    flag5 = (
                        from Map in signi
                        where Map.Signi == 11
                        select Map).Count<KPSigniVO>() < 1;
                    goto Label36;
                }
                Label37:
                flag5 = false;
                Label36:
                Label34:
                if (!flag5)
                {
                    flag23 = true;
                }
            }
            else
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 2
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 10
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        if ((
                            from Map in kPSigniVOs
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() < 1)
                        {
                            goto Label39;
                        }
                        if ((
                            from Map in signi
                            where Map.Signi == 2
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            if ((
                                from Map in signi
                                where Map.Signi == 10
                                select Map).Count<KPSigniVO>() < 1)
                            {
                                goto Label41;
                            }
                            flag9 = (
                                from Map in signi
                                where Map.Signi == 11
                                select Map).Count<KPSigniVO>() < 1;
                            goto Label38;
                        }
                        Label41:
                        flag9 = true;
                        goto Label38;
                    }
                }
                Label39:
                flag9 = true;
                Label38:
                if (!flag9)
                {
                    flag23 = true;
                }
            }
            if (rating == 3)
            {
                if (!flag17 || !flag18 || !flag19 || !flag20)
                {
                    flag8 = true;
                }
                else
                {
                    flag8 = (flag21 || flag23 ? false : !flag22);
                }
                if (!flag8)
                {
                    flag16 = true;
                }
            }
            if (rating == 2)
            {
                if (!flag17 || !flag19 || !flag20)
                {
                    flag7 = true;
                }
                else
                {
                    flag7 = (flag21 ? false : !flag23);
                }
                if (!flag7)
                {
                    flag16 = true;
                }
            }
            if (rating == 1)
            {
                if (!flag17 || !flag19)
                {
                    flag6 = true;
                }
                else
                {
                    flag6 = (flag21 ? false : !flag23);
                }
                if (!flag6)
                {
                    flag16 = true;
                }
            }
            return flag16;
        }

        public bool isBestKundali_KP_Auto(string best_Online_Result, short rating)
        {
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            bool flag4;
            bool flag5;
            bool flag6;
            bool flag7 = false;
            bool flag8 = false;
            bool flag9 = false;
            bool flag10 = false;
            bool flag11 = false;
            bool flag12 = false;
            bool flag13 = false;
            bool flag14 = false;
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            kPHouseMappingVOs = new List<KPHouseMappingVO>();
            KPBLL kPBLL = new KPBLL();
            KundliVO kundliVO = new KundliVO()
            {
                Male = true
            };
            ProductSettingsVO productSettingsVO = new ProductSettingsVO();
            kPBLL.Process_Planet_Lagan(best_Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, 1, false);
            kPPlanetMappingVOs = kPBLL.Process_KPChart_GoodBad(kPPlanetMappingVOs, kundliVO, productSettingsVO);
            List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
            List<KPSigniVO> signi = new List<KPSigniVO>();
            short subLord = 0;
            short nakLord = 0;
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 7
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if ((
                from Map in signi
                where Map.Signi == 2
                select Map).Count<KPSigniVO>() < 1)
            {
                if ((
                    from Map in signi
                    where Map.Signi == 7
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    goto Label1;
                }
                flag = (
                    from Map in signi
                    where Map.Signi == 11
                    select Map).Count<KPSigniVO>() < 1;
                goto Label0;
            }
            Label1:
            flag = false;
            Label0:
            if (!flag)
            {
                flag8 = true;
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 5
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (((
                from Map in signi
                where Map.Signi == 2
                select Map).Count<KPSigniVO>() >= 1 ? true : (
                from Map in signi
                where Map.Signi == 5
                select Map).Count<KPSigniVO>() >= 1))
            {
                flag9 = true;
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 6
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if ((
                from Map in kPSigniVOs
                where Map.Signi == 5
                select Map).Count<KPSigniVO>() < 1)
            {
                if ((
                    from Map in kPSigniVOs
                    where Map.Signi == 6
                    select Map).Count<KPSigniVO>() == 1)
                {
                    goto Label3;
                }
                flag1 = (
                    from Map in kPSigniVOs
                    where Map.Signi == 8
                    select Map).Count<KPSigniVO>() != 0;
                goto Label2;
            }
            Label3:
            flag1 = false;
            Label2:
            if (!flag1)
            {
                flag10 = true;
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 2
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (((
                from Map in signi
                where Map.Signi == 2
                select Map).Count<KPSigniVO>() >= 1 ? true : (
                from Map in signi
                where Map.Signi == 11
                select Map).Count<KPSigniVO>() >= 1))
            {
                flag11 = true;
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 7
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if ((
                from Map in signi
                where Map.Signi == 2
                select Map).Count<KPSigniVO>() < 1)
            {
                if ((
                    from Map in signi
                    where Map.Signi == 7
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    goto Label5;
                }
                flag2 = (
                    from Map in signi
                    where Map.Signi == 11
                    select Map).Count<KPSigniVO>() < 1;
                goto Label4;
            }
            Label5:
            flag2 = false;
            Label4:
            if (!flag2)
            {
                flag13 = true;
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 6
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if (((
                from Map in signi
                where Map.Signi == 10
                select Map).Count<KPSigniVO>() >= 1 ? true : (
                from Map in signi
                where Map.Signi == 11
                select Map).Count<KPSigniVO>() >= 1))
            {
                flag12 = true;
            }
            subLord = (
                from Map1 in kPHouseMappingVOs
                where Map1.House == 10
                select Map1).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            nakLord = (
                from Map1 in kPPlanetMappingVOs
                where Map1.Planet == subLord
                select Map1).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            kPSigniVOs = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if ((
                from Map in signi
                where Map.Signi == 2
                select Map).Count<KPSigniVO>() < 1)
            {
                if ((
                    from Map in signi
                    where Map.Signi == 10
                    select Map).Count<KPSigniVO>() >= 1)
                {
                    goto Label7;
                }
                flag3 = (
                    from Map in signi
                    where Map.Signi == 11
                    select Map).Count<KPSigniVO>() < 1;
                goto Label6;
            }
            Label7:
            flag3 = false;
            Label6:
            if (!flag3)
            {
                flag14 = true;
            }
            if (rating == 3)
            {
                if (!flag8 || !flag9 || !flag10 || !flag11)
                {
                    flag6 = true;
                }
                else
                {
                    flag6 = (flag12 || flag14 ? false : !flag13);
                }
                if (!flag6)
                {
                    flag7 = true;
                }
            }
            if (rating == 2)
            {
                if (!flag8 || !flag10 || !flag11)
                {
                    flag5 = true;
                }
                else
                {
                    flag5 = (flag12 ? false : !flag14);
                }
                if (!flag5)
                {
                    flag7 = true;
                }
            }
            if (rating == 1)
            {
                if (!flag8 || !flag10)
                {
                    flag4 = true;
                }
                else
                {
                    flag4 = (flag12 ? false : !flag14);
                }
                if (!flag4)
                {
                    flag7 = true;
                }
            }
            return flag7;
        }

        public bool isBestKundali_RedBook(string best_Online_Result, short rating)
        {
            bool flag = false;
            short num = 0;
            short num1 = 0;
            short num2 = 0;
            short num3 = 0;
            short num4 = 0;
            short num5 = 0;
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            kPHouseMappingVOs = new List<KPHouseMappingVO>();
            KPBLL kPBLL = new KPBLL();
            KundliVO kundliVO = new KundliVO()
            {
                Male = true
            };
            ProductSettingsVO productSettingsVO = new ProductSettingsVO();
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            KPDAO kPDAO = new KPDAO();
            kPBLL.Process_Planet_Lagan(best_Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, 1, false);
            kPPlanetMappingVOs = kPBLL.Process_KPChart_GoodBad(kPPlanetMappingVOs, kundliVO, productSettingsVO);
            foreach (KPPlanetMappingVO kPPlanetMappingVO in kPPlanetMappingVOs)
            {
                kPMixDashaVOs = kPDAO.Get_Mix_Dasha(kPPlanetMappingVO.Planet, kPPlanetMappingVO.House, 1, productSettingsVO.Product, "fullyog").ToList<KPMixDashaVO>();
                kPMixDashaVOs.AddRange(kPDAO.Get_Mix_Dasha(kPPlanetMappingVO.Planet, kPPlanetMappingVO.House, 1, productSettingsVO.Product, "fullyuti").ToList<KPMixDashaVO>());
                kPMixDashaVOs.AddRange(kPDAO.Get_Mix_Dasha(kPPlanetMappingVO.Planet, kPPlanetMappingVO.House, 1, productSettingsVO.Product, "fulltriangle").ToList<KPMixDashaVO>());
                foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
                {
                    if ((kPMixDashaVO.ptype != "fullyog" ? false : !kPMixDashaVO.Isbad))
                    {
                        num1 = (short)(num1 + 1);
                    }
                    if ((kPMixDashaVO.ptype != "fullyog" ? false : kPMixDashaVO.Isbad))
                    {
                        num4 = (short)(num4 + 1);
                    }
                    if ((kPMixDashaVO.ptype != "fullyuti" ? false : !kPMixDashaVO.Isbad))
                    {
                        num = (short)(num + 1);
                    }
                    if ((kPMixDashaVO.ptype != "fullyuti" ? false : kPMixDashaVO.Isbad))
                    {
                        num3 = (short)(num3 + 1);
                    }
                    if ((kPMixDashaVO.ptype != "fulltriangle" ? false : !kPMixDashaVO.Isbad))
                    {
                        num2 = (short)(num2 + 1);
                    }
                    if ((kPMixDashaVO.ptype != "fulltriangle" ? false : kPMixDashaVO.Isbad))
                    {
                        num5 = (short)(num5 + 1);
                    }
                }
            }
            if ((num <= 2 || num1 <= 2 || num2 <= 2 || num3 != 0 || num4 != 0 || num5 != 0 ? false : rating == 3))
            {
                flag = true;
            }
            if ((num <= 1 || num1 <= 1 || num2 <= 1 || num4 != 0 ? false : rating == 2))
            {
                flag = true;
            }
            if ((num <= 2 || num1 <= 2 ? false : rating == 1))
            {
                flag = true;
            }
            return flag;
        }
    }
}