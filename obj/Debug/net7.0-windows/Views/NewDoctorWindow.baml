   M S B A M L   `   `   `  ����C  ?TP2_POO2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TP2_POO2.ViewsTP2_POO2.Views  5   	   1clr-namespace:TP2_POO2.ModelsTP2_POO2.Models  64   $    TP2_POO2.Views.NewDoctorWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	 cMahApps.Metro.IconPacks.Codicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah
 dMahApps.Metro.IconPacks.Coolicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.FileIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Fontaudio, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Fontisto, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.ForkAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.PixelartIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RadixIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.RemixIcon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai  eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj! fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag" cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af# bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj$ fMahApps.Metro.IconPacks.VaadinIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak% gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah& dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a}	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks!    	 
                        ! " # $ % & 5      hlocalclr-namespace:TP2_POO2.Views!    	 
                        ! " # $ % & 5   	   jmodelsclr-namespace:TP2_POO2.Models!    	 
                        ! " # $ % & 64     � Title$  NewDoctorWindow��5	   	   $	��450��6!   $	��800��6.    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P    � Icon 6u   7  1MahApps.Metro.IconPacks.FontAwesomeImageExtension     Kind$ HandHoldingMedicalSolid=� � 	Resources 5
         backIcon��%�   &	        �� 5   
   $��54��6"   $��24��6-   $��Center=�69   $��Center=�6T   .+�5      F� j����0�I �y� Ѱ.+ `�� �@ŋ `�� �@ŋ  �� Ѱ.+  �� �0�I �.c � z? p�X � � `�� � z? P�� �0�I  �� �0�I �y� 	
���   �6�   5      5      .��5      � $��5,5,5,10q�6    J� RenderTransformOrigin$ 	0.504,0.5&�6    � ColumnDefinitions 5   
   �� 5      $	��37* �6   �� 5      $	��79* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5#   
   �� $	��Nom��6   $	��Top=�6   $��0��66   $��
53,31,53,0q�6F   $��26��6Z   $
��Bold"�6f   $��Italic$�6x   �� 5$   
   $��Center=�6   $��1��6,   $��6��6<   $��40��6I   $��	71,0,71,0q�6z   ��6U   �� *NewCompteCommand+.��5%      �� 	 �� Orientation$	 
Horizontal=�6   .+�5&      1  +MahApps.Metro.IconPacks.PackIconFontAwesome  
   Kind$
 HandshakeSolid=�60   $��Center=�6F   $��25��6a   �� 5'      $��Créer compte��6   $
��Bold"�6/   $��Italic$�6A   5(      5)      �� 5*   
   $	��Top=�6S   $��1��6k   $��Center=�6{   $��26��6�   $��
71,31,71,0q�6�   ��6   �� *
Doctor.Nom+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5,   
   $	��Top=�6}   $��1��6�   $��Center=�6�   $��26��6�   $��
71,17,71,0q�6�   $��2��6�    �� SelectedItem 6   �� *Doctor.Ville+$ PropertyChanged=���6^   �� *Villes+6�   �� 5-   
   $��Ville��6   $
��Left=�6    $��53,0,0,0q�6;   $��2��6M   $��Center=�6Z   $
��Bold"�6u   $��Italic$�6�   $��43��6�   $	��122��6�   �� 5.   
   $��Prénom��6   $��Center=�6!   $��0��6<   $��	53,0,53,0q�6L   $��26��6_   $
��Bold"�6k   $��Italic$�6}   $��1��6�   �� 5/   
   $��Courriel��6   $��Center=�6#   $��0��6>   $��	53,0,53,0q�6N   $��26��6a   $
��Bold"�6m   $��Italic$�6   $��3��6�   �� 50   
   $��Genre��6   $	��Top=�6    $��0��68   $��
53,17,53,0q�6H   $��26��6\   $
��Bold"�6h   $��Italic$�6z   $��4��6�   �� 51   
   $��Center=�6V   $��1��6q   $��Center=�6�   $��26��6�   $��	71,0,71,0q�6�   $��1��6�   ��6   �� *Doctor.Prenom+$ PropertyChanged=�6�   �� 52   
   $��Center=�6X   $��1��6s   $��Center=�6�   $��39��6�   $��	71,0,71,0q�6�   $��3��6�   ��6   �� *Doctor.Courriel+$ PropertyChanged=�6�   �� 54   
   $��71,10,71,10q�6   $��4��6*   $��1��67   .+�55      	� $��Masculin��6    	� 	GroupName$ Gender��6-    d� 	IsChecked 6@   �� *IsMaleSelected+	� 56      $��Féminin��6   $ Gender��6,    6?   �� *IsFemaleSelected+57      �� 5@   
   $��Date de naissance��6   $	��Top=�6,   $��0��6D   $��
53,24,53,0q�6T   $��26��6h   $
��Bold"�6t   $��Italic$�6�   $��5��6�   �� 5A   
   $��1��6}   $��71,13,71,10q�6�   $��5��6�    � ToolTip$* $Entrez une date au format jj/mm/aaaa��6�   ��6   �� *Doctor.DateN+ �� Mode$ TwoWay=�$ PropertyChanged=� �� StringFormat$ 
dd/MM/yyyy��6�   �� 5B   
   $��Center=�6   $��40��6,   $��	39,0,53,0q�6X   $��6��6k   ��68   �� *BackCommand+.��5C      �� $	 
Horizontal=�6   .+�5D      �� #��[  6   $
��Bold"�6<   $��Italic$�6N   5E      5F      5I      5K      