using Altseed2;
using System.Collections.Generic;

namespace Tutorial
{
    // メインステージのクラス
    public class MainNode : Node
    {
        // BGMのID
        private int? bgmID = null;

        // カウンタ
        private int count = 0;

        // 敵を格納するキュー
        private Queue<Enemy> enemies = new Queue<Enemy>();

        // キャラクターを表示するノード
        private Node characterNode = new Node();
        
        // プレイヤーの参照
        private Player player;

+       // スコアを表示するノード
+       private TextNode scoreNode;

        // スコア
        public int score;

        ...略...
