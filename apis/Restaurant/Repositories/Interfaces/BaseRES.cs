using Db.Contexts;

namespace Repositories.Interfaces;

/// <summary>
///     This class is used to inject DbContext for all classes that inherit it
/// </summary>
/// <param name="context"></param>
public class BaseRES(FFOEContext context)
{
    protected FFOEContext context = context;
}