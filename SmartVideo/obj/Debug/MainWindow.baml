   M S B A M L   `   `   `  ����E  ASmartVideo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SmartVideo
SmartVideo  5   	       SmartVideo.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SmartVideo     5   	     � Title$  
SmartVideo��5   	   $��633.5��6   $��1111.5��6+    � 
ResizeMode$ NoResize=�6:   .��5	      � $	��621��6   $	��Top=�6   .+�5
   
   �� -   5         ��Name$ ListView_ListeFilms��5
      $
��Left=�60   $	��458��6K   $��
28,122,0,0q�6X   $	��Top=�6l   $
��1052��6�    �� View 5      �� 5      .P�5      ��  �� Width$ 60��6%   $��
Id du film��60    �� DisplayMemberBinding 5      �� *Id+�� 5      $	 180��6%   $��Titre��61    5      �� *Title+�� 5      $	 180��6%   $��Titre original��61    5      �� *Original_Title+�� 5      $	 100��6%   $��Durée en minutes��61    5      �� *	Runtime+�� 5      $	 250��6%   $��Lien vers l'affiche��61    5      �� *
PosterPath+�� 5      $	 250��6%   $,��&Lien vers la video de la bande-annonce��61    5      �� *TrailerPath+5      5      �� 5   
   -   5         ��Name$ Button_Precedent��5      $��Page précédente��6+   $
��Left=�6E   $��59��6`   $��
489,42,0,0q�6l   $	��Top=�6�   $	��140��6�   $��16(�6�   {�.  6�   �� 5   
   -   5        $ Button_Suivant��5      $��Page suivante��6)   $
��Left=�6A   $��59��6\   $��
634,42,0,0q�6h   $	��Top=�6|   $	��140��6�   $��16(�6�   6�   �� 5   
   -   5         ��Name$ Label_Liste��5      $��Liste de films :��6%   $
��Left=�6@   $��58��6[   $��	28,42,0,0q�6g   $	��Top=�6z   $	��231��6�   $��36(�6�   5       5!      