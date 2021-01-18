namespace Inventory.Shared
{
    /// <summary>
    /// Sort options.
    /// </summary>
    public enum ApplicationFilterColumns
    {
        Cposition,
        Cpositioncode,
        Cinvcode,
        Cinvname,
        Iqty,
        Cticketcode,
        Createtime,
        Createowner,
        Reviewuser,
        Reviewtime,
        Cstatus,

        FlagId,
        FlagName,
        FlagType,
        Sortid,
        Memo,
        Id,
        Code,
        ConfigDesc,
        ConfigValue,
        Caccountid,
        WmsTskId, // not string, cannot use for sorting
        CmdSno
    }
}
