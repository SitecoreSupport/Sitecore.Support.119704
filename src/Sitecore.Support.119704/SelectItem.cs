using Sitecore.Buckets.Managers;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Web.UI.Sheer;
using System;

namespace Sitecore.Support.Buckets.Pipelines.UI.AddFromTemplate
{
    public class SelectItem
    {
        public void Execute(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (!args.HasResult)
            {
                return;
            }
            Item item = (Context.ContentDatabase ?? Context.Database).GetItem(args.Result);
            if (item != null && BucketManager.IsItemContainedWithinBucket(item))
            {
                //Context.ClientPage.ClientResponse.Eval("request.currentCommand = Number.MAX_VALUE;scForm.invoke(\"item:load(id=" + item.ID + ")\")");
                Context.ClientPage.ClientResponse.Eval("setTimeout(function(){ scForm.invoke(\"item:load(id=" + item.ID + ")\"); }, 0)");
            }
        }
    }
}