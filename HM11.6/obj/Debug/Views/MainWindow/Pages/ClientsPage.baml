   M S B A M L   `   `   `  ????A  =HM11.6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HM11._6.Views.MainWindow.PagesHM11._6.Views.MainWindow.Pages  5      S.clr-namespace:HM11._6.ViewModel.MainWindowPage HM11._6.ViewModel.MainWindowPage  5      0    *HM11._6.Views.MainWindow.Pages.ClientsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:HM11._6.Views.MainWindow.Pages     5      D	viewModel.clr-namespace:HM11._6.ViewModel.MainWindowPage     5        N? Title$  ClientsPage??5
       N? 
Background
 ??p?? ? DataContext 5      7   1HM11._6.ViewModel.MainWindowPage.ClientsViewModel  5   
   .??5      ?  ? RowDefinitions 5   
   ?? 5      ?? 5      $
??Auto ?6   .+?5   
   &   System.Windows.Controls.DataGrid  
?????? $??0??5         AutoGenerateColumns .  ??. $
??Auto=?5      $??2??6C   ??5      ?? *	Clients+ ?? SelectedItem 5      ?? *SelectedClient+ ?? SelectedIndex 5      ?? *SelectedIndex+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО??6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 5    %   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5!   %   ?? *FIO+ ?? Mode$ OneWay=?  5"      $' !Паспортные данные??6%   $	 * 5#   %   
 5$   %   ?? *StringPassportData+$ OneWay=?  5%      $ Телефон??6%   $	 * 5&   %   
 5'   %   ?? *NumberPhone+$ OneWay=?5*      ?? 5+   
   $??1??6    ?? Orientation$ 
Horizontal=?6"   $
??Left=?6;   $??2??6W   .+?5,      ?? $??Добавить??6   $??5q?5-      $	??120??6    ??5.      ?? *AddClientCommand+{?5/      ?? *EnableAddClient+?? 50      $ ??Редактировать??6   $??5q?51      $	??120??6    ??52      ?? *EditClientCommand+{?53      ?? *EnableEditClient+?? 54      $??Удалить??6   $??5q?55      $	??120??6    ??56      ?? *DelClientCommand+{?57      ?? *EnableDelClient+?? 58      $&?? Работа со счетами??6   $??5q?59      $	??120??6    ??5:      ?? *AccountClientCommand+{?5;      ?? *EnableAccountClient+?? 5<      $#??Журнал действий??6   $??5q?5=      $	??120??6    ??5>      ?? *OpenHistoryClientCommand+5@      5B      5C      