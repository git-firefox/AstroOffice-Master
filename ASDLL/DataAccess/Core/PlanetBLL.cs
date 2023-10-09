using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using AstroShared.Models;

namespace ASDLL.DataAccess.Core
{
    public class PlanetBLL
    {
        public PlanetBLL()
        {
        }

        public List<PlanetMAPVO> FillAllPlanets()
        {
            List<PlanetMAPVO> planetMAPVOs = new List<PlanetMAPVO>();
            foreach (DataRow row in (new PlanetDAO()).GetAllPlanets().Rows)
            {
                PlanetMAPVO planetMAPVO = new PlanetMAPVO()
                {
                    NewAstro = Convert.ToInt64(row["sno"].ToString())
                };
                if (planetMAPVO.NewAstro == (long)1)
                {
                    planetMAPVO.Mangal = (long)8;
                }
                if (planetMAPVO.NewAstro == (long)2)
                {
                    planetMAPVO.Mangal = (long)9;
                }
                if (planetMAPVO.NewAstro == (long)3)
                {
                    planetMAPVO.Mangal = (long)7;
                }
                if (planetMAPVO.NewAstro == (long)4)
                {
                    planetMAPVO.Mangal = (long)2;
                }
                if (planetMAPVO.NewAstro == (long)5)
                {
                    planetMAPVO.Mangal = (long)1;
                }
                if (planetMAPVO.NewAstro == (long)6)
                {
                    planetMAPVO.Mangal = (long)5;
                }
                if (planetMAPVO.NewAstro == (long)7)
                {
                    planetMAPVO.Mangal = (long)6;
                }
                if (planetMAPVO.NewAstro == (long)8)
                {
                    planetMAPVO.Mangal = (long)4;
                }
                if (planetMAPVO.NewAstro == (long)9)
                {
                    planetMAPVO.Mangal = (long)3;
                }
                planetMAPVOs.Add(planetMAPVO);
            }
            return planetMAPVOs;
        }

        public List<PlanetHouseMappingVO> GetAllMandeGhar()
        {
            List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
            foreach (DataRow row in (new PlanetDAO()).GetAllMandeGhar().Rows)
            {
                PlanetHouseMappingVO planetHouseMappingVO = new PlanetHouseMappingVO()
                {
                    Sno = (long)Convert.ToInt32(row["sno"].ToString()),
                    Planet = Convert.ToInt32(row["planet"].ToString()),
                    House = Convert.ToInt32(row["house"].ToString())
                };
                planetHouseMappingVOs.Add(planetHouseMappingVO);
            }
            return planetHouseMappingVOs;
        }

        public List<PlanetHouseMappingVO> GetAllNeechGhar()
        {
            List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
            foreach (DataRow row in (new PlanetDAO()).GetAllNeechGhar().Rows)
            {
                PlanetHouseMappingVO planetHouseMappingVO = new PlanetHouseMappingVO()
                {
                    Sno = (long)Convert.ToInt32(row["sno"].ToString()),
                    Planet = Convert.ToInt32(row["planet"].ToString()),
                    House = Convert.ToInt32(row["house"].ToString())
                };
                planetHouseMappingVOs.Add(planetHouseMappingVO);
            }
            return planetHouseMappingVOs;
        }

        public List<PlanetRelationsVO> GetAllPlanetRelations()
        {
            List<PlanetRelationsVO> planetRelationsVOs = new List<PlanetRelationsVO>();
            foreach (DataRow row in (new PlanetDAO()).GetAllPlanetRealtions().Rows)
            {
                PlanetRelationsVO planetRelationsVO = new PlanetRelationsVO()
                {
                    Sno = Convert.ToInt32(row["sno"]),
                    Planet1 = Convert.ToInt32(row["planet1"]),
                    Planet2 = Convert.ToInt32(row["planet2"]),
                    Relation = Convert.ToInt32(row["relation"])
                };
                planetRelationsVOs.Add(planetRelationsVO);
            }
            return planetRelationsVOs;
        }

        public List<PlanetVO> GetAllPlanets()
        {
            List<PlanetVO> planetVOs = new List<PlanetVO>();
            foreach (DataRow row in (new PlanetDAO()).GetAllPlanets().Rows)
            {
                PlanetVO planetVO = new PlanetVO()
                {
                    Sno = Convert.ToInt32(row["sno"].ToString()),
                    Planetname = row["planet"].ToString(),
                    Color = row["color"].ToString(),
                    Din = row["din"].ToString(),
                    Karya = row["karya"].ToString(),
                    Samay = row["samay"].ToString(),
                    Pakka_ghar = Convert.ToInt32(row["pakka_ghar"].ToString()),
                    Gender = Convert.ToInt32(row["gender"].ToString()),
                    PlanetnameHindi = row["planethindi"].ToString(),
                    PlanetnameEnglish = row["planetenglish"].ToString()
                };
                planetVOs.Add(planetVO);
            }
            return planetVOs;
        }

        public List<PlanetHouseMappingVO> GetAllShreshtGhar()
        {
            List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
            foreach (DataRow row in (new PlanetDAO()).GetAllShreshtGhar().Rows)
            {
                PlanetHouseMappingVO planetHouseMappingVO = new PlanetHouseMappingVO()
                {
                    Sno = (long)Convert.ToInt32(row["sno"].ToString()),
                    Planet = Convert.ToInt32(row["planet"].ToString()),
                    House = Convert.ToInt32(row["house"].ToString())
                };
                planetHouseMappingVOs.Add(planetHouseMappingVO);
            }
            return planetHouseMappingVOs;
        }

        public List<SoyeGrehUpayeVO> GetAllSoyeGrehUpaye()
        {
            List<SoyeGrehUpayeVO> soyeGrehUpayeVOs = new List<SoyeGrehUpayeVO>();
            foreach (DataRow row in (new PlanetDAO()).GetAllSoyeGrehUpaye().Rows)
            {
                SoyeGrehUpayeVO soyeGrehUpayeVO = new SoyeGrehUpayeVO()
                {
                    Sno = Convert.ToInt32(row["sno"].ToString()),
                    Planet = Convert.ToInt32(row["planet"].ToString()),
                    Details = row["jagao"].ToString(),
                    Eng_Details = row["jagao_eng"].ToString(),
                    Bangla_Details = row["bangla"].ToString(),
                    Tamil_Details = row["tamil"].ToString(),
                    Telugu_Details = row["telugu"].ToString(),
                    Kannada_Details = row["kannada"].ToString(),
                    Marathi_Details = row["marathi"].ToString(),
                    Punjabi_Details = row["punjabi"].ToString(),
                    Gujarati_Details = row["gujarati"].ToString()
                };
                soyeGrehUpayeVOs.Add(soyeGrehUpayeVO);
            }
            return soyeGrehUpayeVOs;
        }

        public List<PlanetHouseMappingVO> GetAllUchGhar()
        {
            List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
            foreach (DataRow row in (new PlanetDAO()).GetAllUchGhar().Rows)
            {
                PlanetHouseMappingVO planetHouseMappingVO = new PlanetHouseMappingVO()
                {
                    Sno = (long)Convert.ToInt32(row["sno"].ToString()),
                    Planet = Convert.ToInt32(row["planet"].ToString()),
                    House = Convert.ToInt32(row["house"].ToString())
                };
                planetHouseMappingVOs.Add(planetHouseMappingVO);
            }
            return planetHouseMappingVOs;
        }

        public string GetFixHouse(short house)
        {
            string str = "";
            if (house == 1)
            {
                str = "Guru,Shani,Mangal";
            }
            if (house == 2)
            {
                str = "Guru,Shukra";
            }
            if (house == 3)
            {
                str = "Budh,Shani,Mangal";
            }
            if (house == 4)
            {
                str = "Guru,Surya,Chandra";
            }
            if (house == 5)
            {
                str = "Guru,Surya,Rahu,Ketu";
            }
            if (house == 6)
            {
                str = "Budh,Ketu,Shukra";
            }
            if (house == 7)
            {
                str = "Shukra,Budh";
            }
            if (house == 8)
            {
                str = "Shani,Mangal,Chandra";
            }
            if (house == 9)
            {
                str = "Guru";
            }
            if (house == 10)
            {
                str = "Shani,Rahu,Ketu";
            }
            if (house == 11)
            {
                str = "Shani,Guru";
            }
            if (house == 12)
            {
                str = "Shani,Guru,Rahu";
            }
            return str;
        }

        public List<PlanetHouseMappingVO> GetPakkeGhar()
        {
            List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
            foreach (DataRow row in (new PlanetDAO()).GetAllPakkeGhar().Rows)
            {
                PlanetHouseMappingVO planetHouseMappingVO = new PlanetHouseMappingVO()
                {
                    Sno = (long)Convert.ToInt32(row["sno"].ToString()),
                    Planet = Convert.ToInt32(row["planet"].ToString()),
                    House = Convert.ToInt32(row["house"].ToString())
                };
                planetHouseMappingVOs.Add(planetHouseMappingVO);
            }
            return planetHouseMappingVOs;
        }
    }
}