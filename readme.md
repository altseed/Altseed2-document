# Altseed2 Document

[Altseed2](https://github.com/altseed/altseed2-csharp)のドキュメント

# 生成に必要なもの

- Visual Studio
  - ほかのC#コンパイラでいけるかは不明
  - Homebrew で入れた Mono はダメとある。
- [DocFX](https://github.com/dotnet/docfx)
  - `choco install docfx` するか Release からバイナリを落として解凍し、パスを通す

# 生成

```
docfx metadata
docfx build
```

`docfx --serve` とするとリッチなページがみられる。（CORSに引っかからない）

# 書き方

- 基本的には Markdown。シンタックスについては[ココ](https://github.github.com/gfm/)を参照
- 一部 DocFX 独自拡張があるのでそれについては[ココ](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html?tabs=tabid-1%2Ctabid-a)
  - ソースコード埋め込みとNOTEくらいか
  