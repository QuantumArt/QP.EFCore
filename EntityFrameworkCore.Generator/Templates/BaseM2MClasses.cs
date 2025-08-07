using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates;

internal static class BaseM2MClasses
{
    public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return $@"{context.Settings.GeneratedCodePrefix}
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace {ns};

public abstract class QPLinkBase
{{

    private bool _insertWithArticle = false;
    public bool InsertWithArticle
    {{
        get
        {{
            return _insertWithArticle;
        }}
        set
        {{
            _insertWithArticle = value;
        }}
    }}
        
    private bool _removeWithArticle = false;
    public bool RemoveWithArticle
    {{
        get
        {{
            return _removeWithArticle;
        }}
        set
        {{
            _removeWithArticle = value;
        }}
    }}	
        
    private string _insertingInstruction;
    public string InsertingInstruction
    {{
        get
        {{
            if (String.IsNullOrEmpty(_insertingInstruction))
                SaveInsertingInstruction();
            return _insertingInstruction;
        }}
    }}
        
        
    private string _removingInstruction;
    public string RemovingInstruction
    {{
        get
        {{
            if (String.IsNullOrEmpty(_removingInstruction))
                SaveRemovingInstruction();
            return _removingInstruction;
        }}
    }}
        
    public void SaveRemovingInstruction()
    {{
        _removingInstruction = String.Format(""EXEC sp_executesql N'EXEC qp_delete_single_link @linkId, @itemId, @linkedItemId', N'@linkId NUMERIC, @itemId NUMERIC, @linkedItemId NUMERIC', @linkId = {{0}}, @itemId = {{1}}, @linkedItemId = {{2}}"", this.LinkId, this.Id, this.LinkedItemId);
    }}
        
    public void SaveInsertingInstruction()
    {{
        _insertingInstruction = String.Format(""EXEC sp_executesql N'EXEC qp_insert_single_link @linkId, @itemId, @linkedItemId', N'@linkId NUMERIC, @itemId NUMERIC, @linkedItemId NUMERIC', @linkId = {{0}}, @itemId = {{1}}, @linkedItemId = {{2}}"", this.LinkId, this.Id, this.LinkedItemId);
    }}
        
    public abstract int LinkId {{ get; }}
    public abstract int Id {{ get; }}
    public abstract int LinkedItemId {{ get; }}
    
}}";
    }
}