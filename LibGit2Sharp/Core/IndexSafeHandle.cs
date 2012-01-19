namespace LibGit2Sharp.Core
{
	public class IndexSafeHandle : SafeHandleBase
    {
        protected override bool ReleaseHandle()
        {
            NativeMethods.git_index_free(handle);
            return true;
        }
    }
}
