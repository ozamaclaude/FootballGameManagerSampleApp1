using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismSampleApp1.Utils
{
    public static class Labels
    {
        public static string WD_FileNotFound = "ファイルが見つかりません";
        public static string WD_InsufficientRequiredParameters 
            = "必要な項目が入力されていません\n入力内容を見直してください";
        public const string LabelGameStart = "試合開始";
        public const string LabelGameEnd = "試合終了";
        public const string LabelMen = "男子";
        public const string LabelWomen = "女子";
        public const string LabelSettingMenu = "選手登録";
        public const string LabelGameRecord = "ゲームの記録";
        public const string LabelGameResult = "ゲーム結果";

        public const string TagReplaceCombo = "System.Windows.Controls.ComboBoxItem: ";

        public const string FmtDateTimeFormat1 = "HH:mm:ss";
        public const string FmtDateTimeFormat2 = "yyyy年MM月dd日";
        public const string FmtDateTimeFormat3 = "yyyyMMddHHmmss";
    }
}
