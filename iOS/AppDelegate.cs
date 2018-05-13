using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Utf8Json.Formatters;

namespace SocketClusterFormsApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            //PrimitiveObjectFormatter.Default

            // CompositeResolver is singleton helper for use custom resolver.
            // Ofcourse you can also make custom resolver.

            //Utf8Json.Resolvers.

            //Utf8Json.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
            //    // use generated resolver first, and combine many other generated/custom resolvers
            //    Utf8Json.Resolvers.DynamicCompositeResolver.Create(
            //        new Utf8Json.IJsonFormatter[] { PrimitiveObjectFormatter.Default  }
            //        ,new Utf8Json.IJsonFormatterResolver[] { Utf8Json.Resolvers.DynamicObjectResolver.Default }
            //    )

            //    // set StandardResolver or your use resolver chain
            //    //Utf8Json.Resolvers.DynamicObjectResolver.Default
            //);

            Utf8Json.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
                new[] { PrimitiveObjectFormatter.Default },
                new Utf8Json.IJsonFormatterResolver[]
                {
                    // + code generator resolver(serialize custom type)

                    Utf8Json.Resolvers.BuiltinResolver.Instance,
                    // EnumResolver.Default,(can't serialize enum...)
                    Utf8Json.Resolvers.DynamicGenericResolver.Instance,
                    Utf8Json.Resolvers.AttributeFormatterResolver.Instance
                }
            );

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
