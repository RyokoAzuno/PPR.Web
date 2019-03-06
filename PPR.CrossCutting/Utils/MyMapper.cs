using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.CrossCutting.Utils
{
    // Simple Wrapper class for AutoMapper
    public static class MyMapper<Src, Dest>
    {
        public static IEnumerable<Dest> Map(IEnumerable<Src> source)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Src, Dest>()).CreateMapper();
            var result = mapper.Map<IEnumerable<Src>, List<Dest>>(source);

            return result;
        }

        public static Dest Map(Src source)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Src, Dest>()).CreateMapper();
            var result = mapper.Map<Src, Dest>(source);

            return result;
        }
    }
}
