using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace Benetton.Classes
{
    public class SessionHelper
    {
        public static void ClearSessionOfOtherUserInBranch(int branchid, int userid)
        {
            var obj =
                typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static)
                    .GetValue(null, null);
            var field = obj.GetType().GetField("_caches", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
            {
                var obj2 = (object[])field.GetValue(obj);
                foreach (var t in obj2)
                {
                    var fieldInfo = t.GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (fieldInfo != null)
                    {
                        var c2 = (Hashtable)fieldInfo.GetValue(t);
                        foreach (DictionaryEntry entry in c2)
                        {
                            var o1 =
                                entry.Value.GetType()
                                    .GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance)
                                    .GetValue(entry.Value, null);
                            if (o1.GetType().ToString() != "System.Web.SessionState.InProcSessionState") continue;
                            var info = o1.GetType()
                                .GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance);
                            if (info == null) continue;
                            var sess = (SessionStateItemCollection)info.GetValue(o1);
                            if (sess == null) continue;
                            if (sess["RNDC.session"] == null) continue;
                            var objse = sess["RNDC.session"] as BK_Session;

                            if (objse != null && (branchid == objse.BranchId && userid != objse.UserId))
                            {
                                sess["RNDC.session"] = null;
                            }
                        }
                    }
                }
            }
        }
    }
}