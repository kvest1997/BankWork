   M S B A M L   `   `   `  ????A  =HM11.6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HM11._6.Views.MainWindow.PagesHM11._6.Views.MainWindow.Pages  5      S.clr-namespace:HM11._6.ViewModel.MainWindowPage HM11._6.ViewModel.MainWindowPage  5      3    -HM11._6.Views.MainWindow.Pages.AppSettingPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:HM11._6.Views.MainWindow.Pages     5      D	viewModel.clr-namespace:HM11._6.ViewModel.MainWindowPage     5        N? 
Background
  ????  ? DataContext 5      ;   5HM11._6.ViewModel.MainWindowPage.AppSettingsViewModel  5   
   .??5      ?  ? RowDefinitions 5   
   ?? 5      ?? 5      $
??Auto ?6   .+?5   
   ?? $??0??6    ?? Orientation$ Vertical=?6"   .+?5      ?? $"??Клиенты и счета??6   .??5      ?? $ Vertical=?6   .+?5      ?? $??База Клиентов??6    
???????5       ?? 5      
?????????6    ?? *ClientFilePath+ ?? Mode$ TwoWay=?5       5      5      ?? 5      $??
Счета??6   .??5      ?? $ Vertical=?6   .+?5      ?? $??База счетов??6    
???????5       ?? 5       
?????????6    ?? *AccountFilePath+$ TwoWay=?5!       5"      5#      ?? 5$      $ Vertical=?6   $??Right=?60   .+?5%      ?? $%??Генереция данных??6   $??5q?5&   !   ??5'   !   ?? *GetTestClientsCommand+5(      5*      ?? 5,   
   $??1??6   $ 
Horizontal=?6"   $??Right=?6;   .+?5-      ?? $
??Save??6   $??15, 5q?5/      $	??140??6$    ? Cursor$
 Hand??60   ??5.      ??  ?? Path$ SaveAppSettingsCommand?5/   0   50      52      53      