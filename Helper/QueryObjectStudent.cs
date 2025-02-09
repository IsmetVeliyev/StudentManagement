using System;
namespace StudentManagement.Helper;
public class QueryObjectStudent
{
    public string? Name { get; set; } = null;
    public string? YasUper { get; set; }=null;

    public string? YasLower { get; set; }=null;

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 20;

}
