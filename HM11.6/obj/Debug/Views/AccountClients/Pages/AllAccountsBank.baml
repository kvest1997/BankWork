   M S B A M L   `   `   `  ????A  =HM11.6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:HM11._6.Views.AccountClients.Pages"HM11._6.Views.AccountClients.Pages  5      O,clr-namespace:HM11._6.ViewModel.AccountsBankHM11._6.ViewModel.AccountsBank  5      8    2HM11._6.Views.AccountClients.Pages.AllAccountsBank   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:HM11._6.Views.AccountClients.Pages     5      B	viewModel,clr-namespace:HM11._6.ViewModel.AccountsBank     5        N? 
Background
  ????  N? Title$ AllAccountsBank??5       ? DataContext 5      @   :HM11._6.ViewModel.AccountsBank.CurrentAccountBankViewModel  5   
   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      .+?5   
   ?? $??0??6    ?? Orientation$ 
Horizontal=?6"   $
??Left=?6;   .+?5      ?? $??Открыть счет??6   $??5q?5      $??12(?5      $??25??5      ??5      ?? *OpenNewAccountBank+?? 5      $??Закрыть счет??6   $??5q?5      $??12(?5      $??25??5      ??5      ?? *CloseAccountBank+?? 5       $!??Пополнить счет??6   $??5q?5!      $??12(?5"      $??25??5#      ??5$      ?? *AddBalanceAccount+5%      &   System.Windows.Controls.DataGrid  5'   
   
?????? $??1??5(         AutoGenerateColumns .  ??. $
??Auto=?5+      ??5,      ?? *
Accounts+ ?? SelectedIndex 5-      ?? *SelectedIndex+ ?? SelectedItem 5.      ?? *SelectedAccount+   Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Счет??6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 52   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 51   %   ?? *BankAccount+ ?? Mode$ OneWay=?52   %     53      $	 Тип счета??6%   $
 * 55   %    54   %   ?? *TypeAccountBank+$ OneWay=?55   %     56      $	 Баланс??6%   $
 * 58   %    57   %   ?? *BalanceAccount+$ OneWay=?58   %   5:      5;      5<      