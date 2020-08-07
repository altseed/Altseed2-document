using Altseed2;
using System.Collections.Generic;

namespace Tutorial
{
    // メインステージのクラス
    public class MainNode : Node
    {

        ...略...

        // エンジンに追加された時に実行
        protected override void OnAdded()
        {
            // キャラクターノードを追加
            AddChildNode(characterNode);

            // UIを表示するノード
            var uiNode = new Node();

            // UIノードを追加
            AddChildNode(uiNode);

            // 背景に使用するテクスチャ
            var backTexture = new SpriteNode();
            // 背景のテクスチャを読み込む
            backTexture.Texture = Texture2D.LoadStrict("Resources/Background.png");
            // 表示位置を奥に設定
            backTexture.ZOrder = -100;

            // 背景テクスチャを追加
            AddChildNode(backTexture);

            // プレイヤーを設定
            player = new Player(this, new Vector2F(100, 360));

            // キャラクターノードにプレイヤーを追加
            characterNode.AddChildNode(player);

            // スコアを表示するノードを設定
            scoreNode = new TextNode();
            // スコア表示に使うフォントを読み込む
            scoreNode.Font = Font.LoadDynamicFontStrict("Resources/GenYoMinJP-Bold.ttf", 30);
            // スコア表示の位置を設定
            scoreNode.Position = new Vector2F();
-           // スコア表示の文字を設定
-           scoreNode.Text = "スコア";

            // UIノードにスコア表示ノードを追加
            uiNode.AddChildNode(scoreNode);

            // ウェーブを初期化する
            InitWave();

            // BGMを初期化する
            InitBGM();
        }

        ...略...

        // フレーム毎に実行
        protected override void OnUpdate()
        {
+           // スコア表示の更新
+           scoreNode.Text = "Score : " + score;

            // ステージの更新
            UpdateStage();

            // カウントを進める
            count++;
        }

        ...略...

    }
}
