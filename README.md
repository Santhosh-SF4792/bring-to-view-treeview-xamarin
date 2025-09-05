# bring-to-view-treeview-xamarin
This example illustrates how to Bring TreeView into View

## Sample

### XAML
```xaml
<ContentPage.Behaviors>
    <local:TreeViewBehavior/>
</ContentPage.Behaviors>

<ContentPage.BindingContext>
    <local:FileManagerViewModel x:Name="viewModel"/>
</ContentPage.BindingContext>

<StackLayout>
    <Button x:Name="bringIntoView" Text="BringIntoView" HeightRequest="50"/>
    <syncfusion:SfTreeView x:Name="treeView" ChildPropertyName="SubFiles" ItemTemplateContextType="Node" AutoExpandMode="AllNodesExpanded" ItemsSource="{Binding ImageNodeInfo}">
        <syncfusion:SfTreeView.ItemTemplate>
            <DataTemplate>
                <Grid x:Name="grid" RowSpacing="0" >
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="40" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Image Source="{Binding Content.ImageIcon}" VerticalOptions="Center" HorizontalOptions="Center" HeightRequest="35" WidthRequest="35"/>
                    <Grid Grid.Column="1" RowSpacing="1" Padding="1,0,0,0" VerticalOptions="Center">
                        <Label LineBreakMode="NoWrap" Text="{Binding Content.ItemName}" VerticalTextAlignment="Center"/>
                    </Grid>
                </Grid>
            </DataTemplate>
        </syncfusion:SfTreeView.ItemTemplate>
    </syncfusion:SfTreeView>
</StackLayout>
```

### Behavior
```csharp
public class TreeViewBehavior : Behavior<ContentPage>
{
    #region Fields

    private SfTreeView TreeView;
    private Button Button;
    #endregion

    #region Overrides
    protected override void OnAttachedTo(ContentPage bindable)
    {
        TreeView = bindable.FindByName<SfTreeView>("treeView");
        Button = bindable.FindByName<Button>("bringIntoView");
        Button.Clicked += BringIntoView_Clicked;

        base.OnAttachedTo(bindable);
    }

    protected override void OnDetachingFrom(ContentPage bindable)
    {
        Button.Clicked -= BringIntoView_Clicked;
        Button = null;
        TreeView = null;
        base.OnDetachingFrom(bindable);
    }

    #endregion

    #region CallBack
    private void BringIntoView_Clicked(object sender, EventArgs e)
    {
        var viewModel = (sender as Button).BindingContext as FileManagerViewModel;
        var count = viewModel.ImageNodeInfo.Count;
        var data = viewModel.ImageNodeInfo[count - 1];
        TreeView.BringIntoView(data);
    }
    #endregion
}
```

## Requirements to run the demo
Visual Studio 2017 or Visual Studio for Mac.
Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.

## Conclusion

I hope you enjoyed learning about This example illustrates how to Bring Xamarin.Forms TreeView (SfTreeView) into View.

You can refer to our Xamarin.Forms TreeViewfeature tour page to know about its other groundbreaking feature representations and documentation, and how to quickly get started for configuration specifications.

For current customers, you can check out our components from the License and Downloads page. If you are new to Syncfusion, you can try our 30-day free trial to check out our other controls.

If you have any queries or require clarifications, please let us know in the comments section below. You can also contact us through our support forums, Direct-Trac, or feedback portal. We are always happy to assist you!