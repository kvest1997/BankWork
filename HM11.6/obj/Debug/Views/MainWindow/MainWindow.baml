   M S B A M L   `   `   `  ????A  =HM11.6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:HM11._6HM11._6  5   	   S.clr-namespace:HM11._6.ViewModel.MainWindowPage HM11._6.ViewModel.MainWindowPage  5	   	       HM11._6.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:HM11._6     5   	   D	viewModel.clr-namespace:HM11._6.ViewModel.MainWindowPage     5	   	   -   5          ?Name$  mainWin??5   	   $	??400??5
   !   $	??700??6.    ? WindowStartupLocation$ CenterScreen=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? Title 5
   	   ?? *Title+ ? DataContext 5      :   4HM11._6.ViewModel.MainWindowPage.MainWindowViewModel  5   
   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??0.2* ?6   ?? 5      $??* ?6   .+?5   
   ?? $??0??6    ?? Orientation$ 
Horizontal=?6"   $??10q?6;   $
??Left=?6G   $??Center=?6b   .+?5      ?? $??Клиенты??6   $??5q?5      $??15(?5      $??30??5      ??5      ??  ?? Path$ SetClientsView??? 5      $??Настройки??6   $??5q?5      $??15(?5      $??30??5       ??5!      ?? $ SetAppSettingsView??? 5#      $??
Выход??6   $??5q?5$      $??15(?5%      $??30??5&      ??5'      ?? $ LogOutCommand???5(      ??  ?? ElementName$ mainWin??5*      ?? 5,   
   $??5q?5-      $??30??5.      $??Right=?5/      $??Center=?50      $??0??51      .??52      ?? $??15(?6   ??53      ?? $ Worker?54       ? 57   
   $??1??58      $??10q?59      	  ? NavigationUIVisibility$	 Hidden=?5:      ??5;      ?? *CurrentPage+
 J? Opacity
 5<      ?? *FrameOpacity+5=      5>      