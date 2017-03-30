using Sitecore.Buckets.Managers;
using Sitecore.Data.Events;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System;

namespace Sitecore.Support.Buckets.Pipelines.UI
{
    [Serializable]
    public class AddMaster : Sitecore.Shell.Framework.Commands.AddMaster
    {
        public AddMaster()
        {
            base.ItemCreated += new ItemCreatedDelegate(this.OnItemCreated);
        }

        private void OnItemCreated(object sender, ItemCreatedEventArgs args)
        {
            Assert.ArgumentNotNull(sender, "sender");
            Assert.ArgumentNotNull(args, "args");
            Item item = args.Item;
            if (item != null && BucketManager.IsItemContainedWithinBucket(item))
            {
                //Context.ClientPage.ClientResponse.Eval("request.currentCommand = Number.MAX_VALUE;scForm.invoke(\"item:load(id=" + item.ID + ")\")");
                Context.ClientPage.ClientResponse.Eval("setTimeout(function(){ scForm.invoke(\"item:load(id=" + item.ID + ")\"); }, 0)");
            }
        }
    }
}