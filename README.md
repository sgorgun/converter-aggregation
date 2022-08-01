# Transformer. Composition vs Aggregation. (in progress)

## Task Description

Develop a type system that allows you to convert real number to its string representations in any given language.

### Composition Dictionary Scenario

- Implement [Transformer](TransformerDictionaryComposition/Transformer) class that converts real number to its "word format" in any given language. String presentation depend on the language and the set of words that are presented by a `СharactersDictionary` class. The `Transformer` class controls the creation time of an object of this class (SymbolsDictionary composition).

    - [Сharacter](TransformerDictionaryComposition/Сharacter) enum - an enumeration containing a set of words for all characters that a real number can contain.
    - [CharactersDictionary](TransformerDictionaryComposition/CharactersDictionary) class - presents the dictionary of correspondences of the number characters to their word analogs in given language. 
    - [ISymbolsDictionaryProvider](TransformerDictionaryComposition/IСharactersDictionaryProvider) interface - presents the provider of the dictionary of dictionary of correspondences of symbols to their word analogs in given language.

- Run [unit и mock tests]((/Transformer.Tests/TransformerCompositionTests.cs).)
- Use ability [resources files](https://docs.microsoft.com/en-us/dotnet/core/extensions/work-with-resx-files-programmatically) to test `Transformer` class with various languages (russian, english, german). 

### Aggregation Dictionary Scenario

#### Types

- Implement [Transformer](/TransformerDictionaryAggregarion/Transformer.cs#L6[](url)) class, whose `Transform` instance method converts real number to it's "word format" in some language. The language and the set of words are presented by a settings class wich is passed in `Transformer` class from outside.
- Add [new unit tests](/Transformer.Tests/TransformerAggregationTests.cs).
