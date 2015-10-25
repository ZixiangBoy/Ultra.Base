using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmitMapper {
    public static class EmitMapperExtend {
        public static TDest MapTo<TSrc, TDest>(this TSrc oj) {
            return EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<TSrc, TDest>().Map(oj);
        } 
    }
}
